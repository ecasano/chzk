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
    public class PaymentMethodsController : ApiController
    {
        private chzkEntities db = new chzkEntities();


        // GET: api/ListarMetodosdePago
        [HttpGet]
        [Route("api/listarmetodosdepagos")]
        public IEnumerable<PaymentMethoddt> GetListarMetodoPago()
        {
            return PaymentMethod.ListarMetodoPago();
        }


        // GET: api/PaymentMethods
        public IQueryable<PaymentMethod> GetPaymentMethod()
        {
            return db.PaymentMethod;
        }

        // GET: api/PaymentMethods/5
        [ResponseType(typeof(PaymentMethod))]
        public IHttpActionResult GetPaymentMethod(string id)
        {
            PaymentMethod paymentMethod = db.PaymentMethod.Find(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            return Ok(paymentMethod);
        }

        // PUT: api/PaymentMethods/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentMethod(string id, PaymentMethod paymentMethod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentMethod.paymentMethod1)
            {
                return BadRequest();
            }

            db.Entry(paymentMethod).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentMethodExists(id))
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

        // POST: api/PaymentMethods
        [ResponseType(typeof(PaymentMethod))]
        public IHttpActionResult PostPaymentMethod(PaymentMethod paymentMethod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentMethod.Add(paymentMethod);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaymentMethodExists(paymentMethod.paymentMethod1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = paymentMethod.paymentMethod1 }, paymentMethod);
        }

        // DELETE: api/PaymentMethods/5
        [ResponseType(typeof(PaymentMethod))]
        public IHttpActionResult DeletePaymentMethod(string id)
        {
            PaymentMethod paymentMethod = db.PaymentMethod.Find(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            db.PaymentMethod.Remove(paymentMethod);
            db.SaveChanges();

            return Ok(paymentMethod);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentMethodExists(string id)
        {
            return db.PaymentMethod.Count(e => e.paymentMethod1 == id) > 0;
        }
    }
}