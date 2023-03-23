using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloridaBikeShop.Models.ViewModels.Bicicleta_Models
{
    public class Modelo_Bicicleta
    {
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public long Valor_Bicicleta { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public string Propietario { get; set; }

    }
}