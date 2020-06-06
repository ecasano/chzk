
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApiChzk1.Models;
using WebApiChzk1.Transfer;

namespace WebApiChzk1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StoresController : ApiController
    {
        private chzkEntities db = new chzkEntities();

        // GET: api/Tiendas //
        [HttpGet]
        [Route("api/tiendas")]
        public IEnumerable<Storedt> GetTiendas()
        {
            return Store.Tiendas();
        }

        // GET: api/TiendasPorPais
        [HttpGet]
        [Route("api/tiendasXpais")]
        public IEnumerable<Storedt> GetTiendasPorPais(string pais, string direccion)
        {
            return Store.TiendasPorPais(pais, direccion);
        }

        // GET: api/ListarTiendasdeRecojo
        [HttpGet]
        [Route("api/listartiendas")]
        public IEnumerable<Storedt> GetListarTiendas(string distrito, string direccion, string referencia)
        {
            return Store.ListarTiendas(distrito, direccion, referencia);
        }

        // GET: api/Stores
        public IQueryable<Store> GetStore()
        {
            return db.Store;
        }

        // GET: api/Stores/5
        [ResponseType(typeof(Store))]
        public IHttpActionResult GetStore(int id)
        {
            Store store = db.Store.Find(id);
            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        // PUT: api/Stores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStore(int id, Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != store.storeId)
            {
                return BadRequest();
            }

            db.Entry(store).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Stores
        [ResponseType(typeof(Store))]
        public IHttpActionResult PostStore(Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Store.Add(store);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = store.storeId }, store);
        }

        // DELETE: api/Stores/5
        [ResponseType(typeof(Store))]
        public IHttpActionResult DeleteStore(int id)
        {
            Store store = db.Store.Find(id);
            if (store == null)
            {
                return NotFound();
            }

            db.Store.Remove(store);
            db.SaveChanges();

            return Ok(store);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StoreExists(int id)
        {
            return db.Store.Count(e => e.storeId == id) > 0;
        }
    }
}