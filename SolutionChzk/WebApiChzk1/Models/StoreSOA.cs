using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiChzk1.Transfer;

namespace WebApiChzk1.Models
{
    public partial class Store
    {
        public static IEnumerable<Storedt> Tiendas()
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.Store
                       select new Storedt()
                       {
                           storeId = b.storeId,
                           district = b.district

                       };
            return list;
        }
    }
}