using peruscanner.ViewModels;
using peruscanner.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace peruscanner
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute("detalleproducto", typeof(DetalleProductoPage)); // Registra la ruta para el detalle del producto
            Routing.RegisterRoute("QRScannerPage", typeof(QRScannerPage));


        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void OnQRScannerClicked(object sender, EventArgs e)
        {
            // Navega a la página del lector QR 
            await Shell.Current.GoToAsync("QRScannerPage");
        }
    }
}
