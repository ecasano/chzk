
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
    public class ModesController : ApiController
    {
        private chzkEntities db = new chzkEntities();


        // GET: api/ListarModoEnvio
        [HttpGet]
        [Route("api/listarmodoenvio")]
        public IEnumerable<Modedt> GetMododeEnvio()
        {
            return Mode.MododeEnvio();
        }


        // GET: api/Modes
        public IQueryable<Mode> GetMode()
        {
            return db.Mode;
        }

        // GET: api/Modes/5
        [ResponseType(typeof(Mode))]
        public IHttpActionResult GetMode(string id)
        {
            Mode mode = db.Mode.Find(id);
            if (mode == null)
            {
                return NotFound();
            }

            return Ok(mode);
        }

        // PUT: api/Modes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMode(string id, Mode mode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mode.mode1)
            {
                return BadRequest();
            }

            db.Entry(mode).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeExists(id))
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

        // POST: api/Modes
        [ResponseType(typeof(Mode))]
        public IHttpActionResult PostMode(Mode mode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mode.Add(mode);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ModeExists(mode.mode1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mode.mode1 }, mode);
        }

        // DELETE: api/Modes/5
        [ResponseType(typeof(Mode))]
        public IHttpActionResult DeleteMode(string id)
        {
            Mode mode = db.Mode.Find(id);
            if (mode == null)
            {
                return NotFound();
            }

            db.Mode.Remove(mode);
            db.SaveChanges();

            return Ok(mode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModeExists(string id)
        {
            return db.Mode.Count(e => e.mode1 == id) > 0;
        }
    }
}