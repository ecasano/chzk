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
    public class DocumentTypesController : ApiController
    {
        private chzkEntities db = new chzkEntities();

        // GET: api/ListarTamaños
        [HttpGet]
        [Route("api/listartipodocumento")]
        public IEnumerable<DocumentTypedt> GetListarTipoDocumento()
        {
            return DocumentType.ListarTipoDocumento();
        }


        // GET: api/DocumentTypes
        public IQueryable<DocumentType> GetDocumentType()
        {
            return db.DocumentType;
        }

        // GET: api/DocumentTypes/5
        [ResponseType(typeof(DocumentType))]
        public IHttpActionResult GetDocumentType(string id)
        {
            DocumentType documentType = db.DocumentType.Find(id);
            if (documentType == null)
            {
                return NotFound();
            }

            return Ok(documentType);
        }

        // PUT: api/DocumentTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocumentType(string id, DocumentType documentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentType.documentType1)
            {
                return BadRequest();
            }

            db.Entry(documentType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentTypeExists(id))
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

        // POST: api/DocumentTypes
        [ResponseType(typeof(DocumentType))]
        public IHttpActionResult PostDocumentType(DocumentType documentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DocumentType.Add(documentType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DocumentTypeExists(documentType.documentType1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = documentType.documentType1 }, documentType);
        }

        // DELETE: api/DocumentTypes/5
        [ResponseType(typeof(DocumentType))]
        public IHttpActionResult DeleteDocumentType(string id)
        {
            DocumentType documentType = db.DocumentType.Find(id);
            if (documentType == null)
            {
                return NotFound();
            }

            db.DocumentType.Remove(documentType);
            db.SaveChanges();

            return Ok(documentType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentTypeExists(string id)
        {
            return db.DocumentType.Count(e => e.documentType1 == id) > 0;
        }
    }
}