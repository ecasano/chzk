using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiChzk1.Models;

namespace WebApiChzk1.Controllers
{
    public class DeliveriesController : ApiController
    {
        private chzkEntities db = new chzkEntities();

        // GET: api/Deliveries
        public IQueryable<Delivery> GetDelivery()
        {
            return db.Delivery;
        }

        // GET: api/Deliveries/5
        [ResponseType(typeof(Delivery))]
        public IHttpActionResult GetDelivery(int id)
        {
            Delivery delivery = db.Delivery.Find(id);
            if (delivery == null)
            {
                return NotFound();
            }

            return Ok(delivery);
        }

        // PUT: api/Deliveries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDelivery(int id, Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != delivery.deliveryTrackCode)
            {
                return BadRequest();
            }

            db.Entry(delivery).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(id))
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

        // POST: api/Deliveries
        [ResponseType(typeof(Delivery))]
        public IHttpActionResult PostDelivery(Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Delivery.Add(delivery);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = delivery.deliveryTrackCode }, delivery);
        }

        // DELETE: api/Deliveries/5
        [ResponseType(typeof(Delivery))]
        public IHttpActionResult DeleteDelivery(int id)
        {
            Delivery delivery = db.Delivery.Find(id);
            if (delivery == null)
            {
                return NotFound();
            }

            db.Delivery.Remove(delivery);
            db.SaveChanges();

            return Ok(delivery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliveryExists(int id)
        {
            return db.Delivery.Count(e => e.deliveryTrackCode == id) > 0;
        }
    }
}