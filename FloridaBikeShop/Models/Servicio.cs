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
    
    public partial class Servicio
    {
        public long ID { get; set; }
        public string tipo_servicio { get; set; }
        public long valor_servicio { get; set; }
        public System.DateTime fecha_servicio { get; set; }
        public long tecnico { get; set; }
        public long bicicleta { get; set; }
    
        public virtual Bicicleta Bicicleta1 { get; set; }
        public virtual Factura Factura { get; set; }
        public virtual Tecnico Tecnico1 { get; set; }
    }
}