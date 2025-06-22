using Newtonsoft.Json;
using peruscanner.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace peruscanner.Services
{
    internal class TiendaServices
    {
        // Esta clase se encarga de obtener info de una tienda mediande solicitud HTTP a algun endpoint(url)
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _apiURL = "https://apa.educk.cl/api/v1/";
        private readonly string _tienda = "acotango";

        // Obtener tienda
        public async Task<Tienda> ObtenerTienda() // ASíncrono para no esperar cargar toda la app y mostrar info.
        {
            var url = _apiURL + _tienda;
            var respuesta = await _httpClient.GetAsync(url);// Se espera una respuesta sin romper hilo
            if (respuesta.IsSuccessStatusCode) // Exitoso da internamente codigo HTTP 200
            {
                var contenido = await respuesta.Content.ReadAsStringAsync(); // Se lee como string con formato json.
                var tienda = JsonConvert.DeserializeObject<Tienda>(contenido);//contenido json se deserializa a Object Tienda, lista para usar en nuestra app.

                return tienda;
            }
            return null;
        }

        //// Obtener productos
        //public async Task<Tienda> ObtenerProductos() // ASíncrono para no esperar cargar toda la app y mostrar info.
        //{
        //    var url = _apiURL + _tienda + "/productos";
        //    var respuesta = await _httpClient.GetAsync(url);// Se espera una respuesta sin romper hilo
        //    if (respuesta.IsSuccessStatusCode) // Exitoso da internamente codigo HTTP 200
        //    {
        //        var contenido = await respuesta.Content.ReadAsStringAsync(); // Se lee como string con formato json.
        //        var producto = JsonConvert.DeserializeObject<List<Producto>>(contenido);//contenido json se deserializa a Object Tienda, lista para usar en nuestra app.

        //        return producto;
        //    }
        //    return null;
        //}

        //// Obtener producto por id
        //public async Task<Tienda> ObtenerProductos(string codigo) // ASíncrono para no esperar cargar toda la app y mostrar info.
        //{
        //    var url = _apiURL + _tienda + "/productos/" + codigo;
        //    var respuesta = await _httpClient.GetAsync(url);// Se espera una respuesta sin romper hilo
        //    if (respuesta.IsSuccessStatusCode) // Exitoso da internamente codigo HTTP 200
        //    {
        //        var contenido = await respuesta.Content.ReadAsStringAsync(); // Se lee como string con formato json.
        //        var producto = JsonConvert.DeserializeObject<Producto>(contenido);//contenido json se deserializa a Object Tienda, lista para usar en nuestra app.

        //        return producto;
        //    }
        //    return null;
        //}
    }
}
