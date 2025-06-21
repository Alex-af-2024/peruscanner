using System;
using System.Collections.Generic;
using System.Text;

namespace peruscanner.Models
{
    // Crearemos estructura de tienda para que pueda interactuar con api
    internal class Tienda
    {
        public string dominio {  get; set; }
        public string nombre {  get; set; }
        public string color {  get; set; }
        public string logo_path {  get; set; }
        public string icon_path {  get; set; }
        
    }
}
