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
        public static IEnumerable<Storedt> TiendasPorPais(string pais, string direccion)
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.Store.Where(t => t.country == pais && t.address == direccion)
                       select new Storedt()
                       {
                           storeId = b.storeId,
                           district = b.district

                       };
            return list;
        }

        public static IEnumerable<Storedt> ListarTiendas(string distrito, string direccion, string referencia)
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.Store.Where(t => t.district == distrito && t.address == direccion && t.reference == referencia)
                       select new Storedt()
                       {
                           storeId = b.storeId,
                           
                       };
            return list;
        }


    }
}