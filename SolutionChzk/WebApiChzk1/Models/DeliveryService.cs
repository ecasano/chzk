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
    
    public partial class DeliveryService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeliveryService()
        {
            this.DeliveryServiceStatus = new HashSet<DeliveryServiceStatus>();
        }
    
        public int deliveryServiceId { get; set; }
        public int deliveryTrackCode { get; set; }
        public int storeId { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string status { get; set; }
        public byte[] lastupdate { get; set; }
        public string chazkiName { get; set; }
        public string message { get; set; }
    
        public virtual Delivery Delivery { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryServiceStatus> DeliveryServiceStatus { get; set; }
    }
}
