using System.ComponentModel;
using System.Threading.Tasks;
using peruscanner.Models;
using peruscanner.Services;

namespace peruscanner.ViewModels
{
    public class DetalleProductoViewModel : INotifyPropertyChanged
    {
        private readonly ProductoServices _productoService;
        private Producto _producto;

        public Producto Producto
        {
            get => _producto;
            set
            {
                _producto = value;
                OnPropertyChanged(nameof(Producto));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DetalleProductoViewModel(string codigo)
        {
            _productoService = new ProductoServices();
            Task.Run(async () => await LoadProductoAsync(codigo));
        }

        private async Task LoadProductoAsync(string codigo)
        {
            Producto = await _productoService.ObtenerProductoPorCodigo(codigo);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
