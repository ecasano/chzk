using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static void ValidarTienda(string distrito_n, string direccion_n, string referencia_n)
        {
            chzkEntities db = new chzkEntities();
            var otienda = db.Store.First(t => t.district == distrito_n && t.address == direccion_n && t.reference == referencia_n);
            if (otienda == null)
            {
                Store ntienda = new Store()
                {
                    district = distrito_n,
                    address = direccion_n,
                    reference = referencia_n,
                   
                   
                };
                db.Store.Add(ntienda);
                db.SaveChanges();
            }
            else
            {
                           
                //db.Entry(otienda).State = EntityState.Modified;
               // db.SaveChanges();
            }
        }


    }
}