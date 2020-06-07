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

        public static IEnumerable<Storedt> ListarTiendas(string distrito, string direccion, string referencia, string pais)
        {
            chzkEntities db = new chzkEntities();

            var list = from b in db.Store.Where(t => t.district == distrito && t.address == direccion && t.reference == referencia && t.country == pais)
                            select new Storedt()
                                              {
                                                  storeId = b.storeId,
                                                  district = b.district,
                                                  reference = b.reference
                                              };
            /*
            System.Linq.IQueryable<Storedt> list_temp1;
            System.Linq.IQueryable<Storedt> list_temp2;
            System.Linq.IQueryable<Storedt> list_x_distrito;
            System.Linq.IQueryable<Storedt> list_x_direccion;
            System.Linq.IQueryable<Storedt> list_x_referencia;
            System.Linq.IQueryable<Storedt> list_x_pais;

            list_x_distrito = from b in db.Store.Where(t => t.district == distrito)
                                  select new Storedt()
                                  {
                                      storeId = b.storeId,
                                      district = b.district,
                                      reference = b.reference
                                  };
  
                list_x_direccion = from b in db.Store.Where(t => t.address == direccion)
                                   select new Storedt()
                                   {
                                       storeId = b.storeId,
                                       district = b.district,
                                       reference = b.reference
                                   };

                    

                list_x_referencia = from b in db.Store.Where(t => t.reference == referencia)
                                    select new Storedt()
                                    {
                                        storeId = b.storeId,
                                        district = b.district,
                                        reference = b.reference
                                    };
    
                list_x_pais = from b in db.Store.Where(t => t.country == pais)
                              select new Storedt()
                              {
                                  storeId = b.storeId,
                                  district = b.district,
                                  reference = b.reference
                              };

            list_temp1 = buscarTiendas(list_x_distrito, list_x_direccion);
            list_temp2 = buscarTiendas(list_x_referencia, list_x_pais);

            return buscarTiendas(list_temp1, list_temp2);
            */
            return list;
        }

        public static IQueryable<Storedt> buscarTiendas(IQueryable<Storedt> list1, IQueryable<Storedt> list2) {

            IQueryable<Storedt> lista = null;

            if (list1 != null && list2 != null) {
                lista = list1.Intersect(list2);
            }
            else
            {
                if (list1 != null)
                    lista = list1;

                if (list2 != null)
                    lista = list2;
            }

            return lista;
        }

        public static void ValidarTienda(string distrito_n, string direccion_n, string referencia_n, string pais_n)
        {
            chzkEntities db = new chzkEntities();
            var otienda = db.Store.FirstOrDefault(t => t.district == distrito_n && t.address == direccion_n && t.reference == referencia_n && t.country == pais_n);
            if (otienda == null)
            {
                Store ntienda = new Store()
                {
                    district = distrito_n,
                    address = direccion_n,
                    reference = referencia_n,
                    country = pais_n
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