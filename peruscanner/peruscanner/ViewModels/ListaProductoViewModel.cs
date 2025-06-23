using peruscanner.Models;
using peruscanner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace peruscanner.ViewModels
{
    public class ListaProductoViewModel : INotifyPropertyChanged // Lógica detrás de vista
    {
        private readonly ProductoServices _productoServices;
        public ObservableCollection<Producto> Productos { get; set; }
        public ICommand RefreshCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ListaProductoViewModel()
        {
            _productoServices = new ProductoServices();
            Productos = new ObservableCollection<Producto>();

            RefreshCommand = new Command(async () => await LoadProductosAsync());
            // Carga los productos al iniciar
            Task.Run(async () => await LoadProductosAsync());
        }

        // Accede a la API para obtener productos
        private async Task LoadProductosAsync()
        {
            var productos = await _productoServices.ObtenerProductosAsync(); // Usa método de ProductoServices
            Productos.Clear();
            foreach (var producto in productos)
            {
                Productos.Add(producto);
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
