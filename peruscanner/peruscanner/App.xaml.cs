using peruscanner.Services;
using peruscanner.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace peruscanner
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            // Registro de servicios (ejemplo)
            DependencyService.Register<MockDataStore>();

            // Verifica si el usuario está autenticado.
            if (!IsUserLoggedIn())
            {
                // Si no está logueado, establece la LoginPage como página principal.
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                // Si ya está autenticado, muestra el Shell principal.
                MainPage = new AppShell();
            }
        }

        // Método de ejemplo para determinar el estado de autenticación.
        private bool IsUserLoggedIn()
        {
            // Aquí podrías verificar la existencia de un token, usuario guardado, etc.
            // Para esta demostración, siempre retornamos false.
            return false;
        }

        protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }
    }
}
