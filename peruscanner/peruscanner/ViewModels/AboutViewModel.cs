using peruscanner.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace peruscanner.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public string _logoUrl;//variable a guardar  . Siempre agregar estas dos
        public string LogoUrl // Variable a invocar
        {
            get => _logoUrl;
            set => SetProperty(ref _logoUrl, value);
        }

        public string _nombre;//variable a guardar  . Siempre agregar estas dos
        public string Nombre // Variable a invocar
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        public string _color;//variable a guardar  . Siempre agregar estas dos
        public string Color // Variable a invocar
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }




        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            _ = cargarTienda();
        }

        public ICommand OpenWebCommand { get; }

        public async Task cargarTienda()
        {
            var servicio = new TiendaServices();
            var tienda = await servicio.ObtenerTienda();

            if (tienda != null)
            {
                Title = tienda.nombre;
                LogoUrl = tienda.logo_path;
                Color = tienda.color;
                Nombre = tienda.nombre;
            }
        }
    }
}

/*el proceso es el siguiente:
Se llama a la API para obtener los datos de la tienda.
El objeto Tienda contiene la URL (logo_path) que corresponde a la imagen del logo.
Esta URL se asigna a la propiedad LogoUrl en el ViewModel.
El binding en la vista actualiza automáticamente el origen de la imagen (Image Source) utilizando el valor de LogoUrl, 
lo que provoca que Xamarin.Forms descargue y muestre la imagen en tu aplicación móvil.*/