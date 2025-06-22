using peruscanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace peruscanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            // Validación de credenciales de ejemplo.
            if (usernameEntry.Text == "afranco" && passwordEntry.Text == "afranco123")
            {
                //await DisplayAlert("Login", "Inicio de sesión exitoso", "Ok");

                // Una vez autenticado, se sustituye la MainPage por el AppShell.
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "Ok");
                // Se limpian los campos de texto
                usernameEntry.Text = string.Empty;
                passwordEntry.Text = string.Empty;
            }
        }
    }
}
