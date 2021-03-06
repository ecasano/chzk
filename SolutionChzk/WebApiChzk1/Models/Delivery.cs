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
    
    public partial class Delivery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Delivery()
        {
            this.AddressClient = new HashSet<AddressClient>();
            this.DeliveryService = new HashSet<DeliveryService>();
            this.ListItemSold = new HashSet<ListItemSold>();
        }
    
        public int deliveryTrackCode { get; set; }
        public int storeId { get; set; }
        public string proofPayment { get; set; }
        public Nullable<decimal> deliveryCost { get; set; }
        public string mode { get; set; }
        public string paymentMethod { get; set; }
        public string documentType { get; set; }
        public string documentNumber { get; set; }
        public string contactName { get; set; }
        public string companyname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string postalcode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressClient> AddressClient { get; set; }
        public virtual DocumentType DocumentType1 { get; set; }
        public virtual Mode Mode1 { get; set; }
        public virtual PaymentMethod PaymentMethod1 { get; set; }
        public virtual ProofPayment ProofPayment1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryService> DeliveryService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListItemSold> ListItemSold { get; set; }
    }
}
