//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiChzk1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Store
    {
        public int storeId { get; set; }
        public string district { get; set; }
        public string address { get; set; }
        public string reference { get; set; }
        public string country { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string timeZone { get; set; }
    
        public virtual Country Country1 { get; set; }
        public virtual TimeZone TimeZone1 { get; set; }
    }
}
