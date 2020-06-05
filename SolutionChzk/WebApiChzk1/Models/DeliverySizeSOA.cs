using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiChzk1.Transfer;

namespace WebApiChzk1.Models
{
    public partial class DeliverySize
    {
        //listado de tamaños
        public static IEnumerable<DeliverySizedt> ListarTamaños()
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.DeliverySize
                       select new DeliverySizedt()
                       {
                           size = b.size,
                           description = b.description

                       };
            return list;

        }

    }
}