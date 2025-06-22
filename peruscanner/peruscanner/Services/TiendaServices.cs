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
        // Agregado
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _apiURL = "https://apa.educk.cl/api/v1/";
        private readonly string _tienda = "acotango";

        public async Task<Tienda> ObtenerTienda()
        {
            var url = _apiURL + _tienda;
            var respuesta = await _httpClient.GetAsync(url);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = respuesta.Content.ReadAsStringAsync();
                var tienda = JsonConvert.DeserializeObject<Tienda>(contenido);

                return tienda;
            }
            return null;
        }
    }
}
