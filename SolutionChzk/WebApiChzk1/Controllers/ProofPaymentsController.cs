
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
    public class ProofPaymentsController : ApiController
    {
        private chzkEntities db = new chzkEntities();

        // GET: api/ListarComprobantedePago //
        [HttpGet]
        [Route("api/listarcomprobantepago")]
        public IEnumerable<ProofPaymentdt> GetComprobantedePago()
        {
            return ProofPayment.ComprobantedePago();
        }


        // GET: api/ProofPayments
        public IQueryable<ProofPayment> GetProofPayment()
        {
            return db.ProofPayment;
        }

        // GET: api/ProofPayments/5
        [ResponseType(typeof(ProofPayment))]
        public IHttpActionResult GetProofPayment(string id)
        {
            ProofPayment proofPayment = db.ProofPayment.Find(id);
            if (proofPayment == null)
            {
                return NotFound();
            }

            return Ok(proofPayment);
        }

        // PUT: api/ProofPayments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProofPayment(string id, ProofPayment proofPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proofPayment.proofPayment1)
            {
                return BadRequest();
            }

            db.Entry(proofPayment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProofPaymentExists(id))
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

        // POST: api/ProofPayments
        [ResponseType(typeof(ProofPayment))]
        public IHttpActionResult PostProofPayment(ProofPayment proofPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProofPayment.Add(proofPayment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProofPaymentExists(proofPayment.proofPayment1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = proofPayment.proofPayment1 }, proofPayment);
        }

        // DELETE: api/ProofPayments/5
        [ResponseType(typeof(ProofPayment))]
        public IHttpActionResult DeleteProofPayment(string id)
        {
            ProofPayment proofPayment = db.ProofPayment.Find(id);
            if (proofPayment == null)
            {
                return NotFound();
            }

            db.ProofPayment.Remove(proofPayment);
            db.SaveChanges();

            return Ok(proofPayment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProofPaymentExists(string id)
        {
            return db.ProofPayment.Count(e => e.proofPayment1 == id) > 0;
        }
    }
}