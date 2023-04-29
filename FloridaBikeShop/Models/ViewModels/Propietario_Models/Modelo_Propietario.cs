using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloridaBikeShop.Models.ViewModels
{
    public class Modelo_Propietario
    {
        
        public long Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        public string Tipo { get; set; }
        public string Marca { get; set; }
        public long Valor_Bicicleta { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public string Propietario { get; set; }



    }
}