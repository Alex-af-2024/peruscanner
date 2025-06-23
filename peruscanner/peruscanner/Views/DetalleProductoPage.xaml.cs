using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using peruscanner.ViewModels;
using peruscanner.Models;


namespace peruscanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleProductoPage : ContentPage
    {
        public DetalleProductoPage(string codigo)
        {
            InitializeComponent();
            BindingContext = new DetalleProductoViewModel(codigo);
        }
    }
}
