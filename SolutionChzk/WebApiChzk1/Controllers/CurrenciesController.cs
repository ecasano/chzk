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
using WebApiChzk1.Transfer;

namespace WebApiChzk1.Controllers
{
    public class CurrenciesController : ApiController
    {
        private chzkEntities db = new chzkEntities();

        // GET: api/ListarMonedas
        [HttpGet]
        [Route("api/listarmonedas")]
        public IEnumerable<Currencydt> GetListarMonedas()
        {
            return Currency.ListarMonedas();
        }



        // GET: api/Currencies
        public IQueryable<Currency> GetCurrency()
        {
            return db.Currency;
        }

        // GET: api/Currencies/5
        [ResponseType(typeof(Currency))]
        public IHttpActionResult GetCurrency(string id)
        {
            Currency currency = db.Currency.Find(id);
            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        // PUT: api/Currencies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCurrency(string id, Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != currency.currency1)
            {
                return BadRequest();
            }

            db.Entry(currency).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
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

        // POST: api/Currencies
        [ResponseType(typeof(Currency))]
        public IHttpActionResult PostCurrency(Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Currency.Add(currency);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CurrencyExists(currency.currency1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = currency.currency1 }, currency);
        }

        // DELETE: api/Currencies/5
        [ResponseType(typeof(Currency))]
        public IHttpActionResult DeleteCurrency(string id)
        {
            Currency currency = db.Currency.Find(id);
            if (currency == null)
            {
                return NotFound();
            }

            db.Currency.Remove(currency);
            db.SaveChanges();

            return Ok(currency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurrencyExists(string id)
        {
            return db.Currency.Count(e => e.currency1 == id) > 0;
        }
    }
}