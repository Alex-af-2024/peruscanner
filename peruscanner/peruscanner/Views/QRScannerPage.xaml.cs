using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using peruscanner.Services;
using Xamarin.Essentials; // Para Text-to-Speech


namespace peruscanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRScannerPage : ContentPage
    {
        public QRScannerPage()
        {
            InitializeComponent();
        }

        // Evento que se dispara cuando se detecta un código QR
        private void ScannerView_OnScanResult(ZXing.Result result)
        {
            // Es importante detener el scanner para que no siga leyendo
            scannerView.IsScanning = false;

            // Ejecutar en el hilo principal (UI thread)
            Device.BeginInvokeOnMainThread(async () =>
            {
                // Asumimos que el contenido del QR es un URL del tipo:
                // "https://apa.educk.cl/tienda/acotango/producto/CAU01"
                var fullUrl = result.Text?.Trim();
                if (string.IsNullOrWhiteSpace(fullUrl))
                {
                    await DisplayAlert("Error", "Código QR vacío.", "OK");
                    scannerView.IsScanning = true;
                    return;
                }

                // Extraer el código del producto. Separamos por '/' y tomamos el último segmento.
                var parts = fullUrl.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var productCode = parts.Last();

                // Llamamos al servicio para obtener el producto.
                var productoService = new ProductoServices();
                var producto = await productoService.ObtenerProductoPorCodigo(productCode);
                if (producto != null)
                {
                    // Preparar el texto a leer con la voz del teléfono
                    var textToSpeak = $"{producto.nombre}, cuesta {producto.precio_text}";
                    await TextToSpeech.SpeakAsync(textToSpeak);

                    // Opcional: puedes navegar a la página de detalle del producto, si lo deseas.
                    // await Shell.Current.GoToAsync($"producto?codigo={producto.codigo}");
                }
                else
                {
                    await DisplayAlert("Error", "No se encontró el producto.", "OK");
                }

                // Volvemos a activar el escáner o salimos de la página, según lo necesites.
                // Por ejemplo, si deseas mantener el escaneo:
                // scannerView.IsScanning = true;
                // O si deseas regresar:
                await Navigation.PopAsync();
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            scannerView.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            scannerView.IsScanning = false;
            base.OnDisappearing();
        }
    }
}
