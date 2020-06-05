using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiChzk1.Transfer;

namespace WebApiChzk1.Models
{
    public partial class PaymentMethod
    {

        //listado de metodos de pago
        public static IEnumerable<PaymentMethoddt> ListarMetodoPago()
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.PaymentMethod
                       select new PaymentMethoddt()
                       {
                           paymentMethod1 = b.paymentMethod1,
                           description = b.description

                       };
            return list;

        }
    }
}