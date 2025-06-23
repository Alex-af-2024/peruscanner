using Newtonsoft.Json;
using peruscanner.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace peruscanner.Services
{
    class ProductoServices
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _apiURL = "https://apa.educk.cl/api/v1/";
        private readonly string _tienda = "acotango";

        // Método para listar todos los productos
        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            var url = $"{_apiURL}{_tienda}/productos";
            var respuesta = await _httpClient.GetAsync(url);//solicitud get HTTP
            if (respuesta.IsSuccessStatusCode) //HTTP 200 ok}

            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<List<Producto>>(contenido); //Como lista para obtener productos
                return productos;
            }
            return new List<Producto>();
        }

        // Método para obtener un producto por su código (ID)
        public async Task<Producto> ObtenerProductoPorCodigo(string codigo)
        {
            var url = $"{_apiURL}{_tienda}/productos/{codigo}";
            var respuesta = await _httpClient.GetAsync(url);
            if (respuesta.IsSuccessStatusCode) // HTTP 200 ok
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<Producto>(contenido);//Como unico dato para obtener producto
                return producto;
            }
            return null;
        }
    }
}
//Entendido