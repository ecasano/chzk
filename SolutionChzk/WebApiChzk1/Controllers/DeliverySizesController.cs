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
    public class DeliverySizesController : ApiController
    {
        private chzkEntities db = new chzkEntities();

        // GET: api/ListarTamaños
        [HttpGet]
        [Route("api/listartamaños")]
        public IEnumerable<DeliverySizedt> GetListarTamaños()
        {
            return DeliverySize.ListarTamaños();
        }




        // GET: api/DeliverySizes
        public IQueryable<DeliverySize> GetDeliverySize()
        {
            return db.DeliverySize;
        }

        // GET: api/DeliverySizes/5
        [ResponseType(typeof(DeliverySize))]
        public IHttpActionResult GetDeliverySize(string id)
        {
            DeliverySize deliverySize = db.DeliverySize.Find(id);
            if (deliverySize == null)
            {
                return NotFound();
            }

            return Ok(deliverySize);
        }

        // PUT: api/DeliverySizes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeliverySize(string id, DeliverySize deliverySize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliverySize.size)
            {
                return BadRequest();
            }

            db.Entry(deliverySize).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliverySizeExists(id))
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

        // POST: api/DeliverySizes
        [ResponseType(typeof(DeliverySize))]
        public IHttpActionResult PostDeliverySize(DeliverySize deliverySize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeliverySize.Add(deliverySize);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DeliverySizeExists(deliverySize.size))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = deliverySize.size }, deliverySize);
        }

        // DELETE: api/DeliverySizes/5
        [ResponseType(typeof(DeliverySize))]
        public IHttpActionResult DeleteDeliverySize(string id)
        {
            DeliverySize deliverySize = db.DeliverySize.Find(id);
            if (deliverySize == null)
            {
                return NotFound();
            }

            db.DeliverySize.Remove(deliverySize);
            db.SaveChanges();

            return Ok(deliverySize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliverySizeExists(string id)
        {
            return db.DeliverySize.Count(e => e.size == id) > 0;
        }
    }
}