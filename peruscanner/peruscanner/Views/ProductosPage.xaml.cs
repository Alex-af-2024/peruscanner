using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using peruscanner.ViewModels;
using peruscanner.Models;

namespace peruscanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();
            BindingContext = new ListaProductoViewModel();
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Verifica que se haya seleccionado un producto
            if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
                return;

            // Obtiene el producto seleccionado (se asume que es un objeto de tipo Producto)
            var selectedProduct = e.CurrentSelection[0] as Producto;
            if (selectedProduct == null)
                return;

            // Navega a la página de detalle, pasando el código o id del producto seleccionado.
            await Navigation.PushAsync(new DetalleProductoPage(selectedProduct.codigo));

            // Deselecciona el item para permitir futuras selecciones.
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
