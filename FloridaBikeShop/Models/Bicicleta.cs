//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FloridaBikeShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bicicleta
    {
        public long ID { get; set; }
        public string tipo { get; set; }
        public string marca { get; set; }
        public long valor_bicicleta { get; set; }
        public System.DateTime fecha_compra { get; set; }
        public long propietario { get; set; }
    
        public virtual Servicio Servicio { get; set; }
        public virtual Propietario Propietario1 { get; set; }
    }
}
