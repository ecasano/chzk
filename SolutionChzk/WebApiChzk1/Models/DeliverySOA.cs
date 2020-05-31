using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiChzk1.Models
{
    [MetadataType(typeof(Delivery.MetaData))]
    public partial class Delivery
    {

        sealed class MetaData
        {
            [Required]
            public int storeId;

            [Required]
            public string proofPayment;
            
            [Required]
            public string mode;

            [Required]
            public string paymentMethod;

            [Required]
            public string contactName;

            [Required]
            public string email;

            [Required]
            public string phone;

        }
    }
}