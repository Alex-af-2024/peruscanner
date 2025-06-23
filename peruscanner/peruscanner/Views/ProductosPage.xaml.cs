using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using peruscanner.ViewModels;
using peruscanner.Models;

namespace peruscanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductosPage : ContentPage
    {
        public ProductosPage()
        {
            InitializeComponent();
            BindingContext = new ListaProductoViewModel();
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
                return;

            // Se asume que el producto tiene la propiedad "codigo"
            var selectedProduct = e.CurrentSelection[0] as Producto;
            if (selectedProduct == null)
                return;

            // Navega a la página de detalle usando Shell y pasando el parámetro "codigo"
            await Shell.Current.GoToAsync($"producto?codigo={selectedProduct.codigo}");

            // Deselecciona el item para futuras selecciones
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}

