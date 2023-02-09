using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloridaBikeShop.Models.ViewModels
{
    public class ListaTablaPropietario
    {
        public long Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }
        
    }
}