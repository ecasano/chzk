using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiChzk1.Transfer;


namespace WebApiChzk1.Models
{
    public partial class DeliveryService
    {

        public static IEnumerable<DeliveryServicedt> Entregas()
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.DeliveryService
                       select new DeliveryServicedt()
                       {
                           deliveryTrackCode = b.deliveryTrackCode,
                           storeId = b.storeId

                       };
            return list;

        }


        public static IEnumerable<DeliveryServicedt> EntregasPorTienda(string tienda)
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.DeliveryService.Where(t => t.storeId == tienda)
                       select new DeliveryServicedt()
                       {
                           deliveryTrackCode = b.DeliveryTrackCode,
                           storeId = b.storeId

                       };
            return list;
        }



    }

}
