using System;
using System.Collections.Generic;
using System.Text;

namespace peruscanner.Models
{
    // Crearemos estructura de producto para que pueda interactuar con api
    public class Producto
    {
        public string id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public string precio_text { get; set; }
        public string logo { get; set; }
        public string url { get; set; }
    }
}
