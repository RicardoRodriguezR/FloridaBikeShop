using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FloridaBikeShop.Models.ViewModels.Bicicleta_Models
{
    public class Formulario_Bicicleta
    {
        public long Id_Bicicleta { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
        [Required]
        [Display(Name = "Mara")]
        public string Marca { get; set; }
        [Required]
        [Display(Name = "Valor Bicicleta")]
        public long Valor_Bicicleta { get; set; }
        [Required]
        [Display(Name = "Feca de compra")]
        public DateTime Fecha_compra { get; set; }
        [Required]
        [Display(Name = "Prpietario")]
        public Propietario Propietario { get; set; }
    }
}