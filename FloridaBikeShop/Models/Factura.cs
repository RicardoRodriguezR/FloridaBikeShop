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
    
    public partial class Factura
    {
        public long ID { get; set; }
        public long servicio { get; set; }
        public long valor { get; set; }
        public System.DateTime fecha { get; set; }
        public long cliente_propietario { get; set; }
        public long tecnico { get; set; }
        public long bicicleta { get; set; }
        public string detalles { get; set; }
    
        public virtual Servicio Servicio1 { get; set; }
    }
}