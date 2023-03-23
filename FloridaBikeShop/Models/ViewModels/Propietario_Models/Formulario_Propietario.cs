using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FloridaBikeShop.Models.ViewModels
{
    public class Formulario_Propietario
    {
        public long Id_Propietario { get; set; }
        [Required]
        [Display(Name = "Documento")]
        public string Documento { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        public long Telefono { get; set; }
        [Required]
        [Display(Name = "Direccion ")]
        public string Direccion { get; set; }
    } 
}