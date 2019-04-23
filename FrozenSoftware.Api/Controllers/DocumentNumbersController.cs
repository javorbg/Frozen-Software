using FrozenSoftware.Api.Models;
using FrozenSoftware.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace FrozenSoftware.Api.Controllers
{
    public class DocumentNumbersController : ApiController
    {
        private FrozenSoftwareApiContext db = new FrozenSoftwareApiContext();

        // GET: api/DocumentNumbers
        public IQueryable<DocumentNumber> GetDocumentNumbers()
        {
            return db.DocumentNumbers;
        }

        // GET: api/DocumentNumbers/5
        [ResponseType(typeof(DocumentNumber))]
        public IHttpActionResult GetDocumentNumber(int id)
        {
            DocumentNumber documentNumber = db.DocumentNumbers.Find(id);
            if (documentNumber == null)
            {
                return NotFound();
            }

            return Ok(documentNumber);
        }

        // PUT: api/DocumentNumbers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocumentNumber(int id, DocumentNumber documentNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentNumber.Id)
            {
                return BadRequest();
            }

            db.Entry(documentNumber).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentNumberExists(id))
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

        // POST: api/DocumentNumbers
        [ResponseType(typeof(DocumentNumber))]
        public IHttpActionResult PostDocumentNumber(DocumentNumber documentNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DocumentNumbers.Add(documentNumber);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = documentNumber.Id }, documentNumber);
        }

        // DELETE: api/DocumentNumbers/5
        [ResponseType(typeof(DocumentNumber))]
        public IHttpActionResult DeleteDocumentNumber(int id)
        {
            DocumentNumber documentNumber = db.DocumentNumbers.Find(id);
            if (documentNumber == null)
            {
                return NotFound();
            }

            db.DocumentNumbers.Remove(documentNumber);
            db.SaveChanges();

            return Ok(documentNumber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentNumberExists(int id)
        {
            return db.DocumentNumbers.Count(e => e.Id == id) > 0;
        }

        private bool EntityLockIdExists(Guid lockId)
        {
            return db.DocumentNumbers.Count(e => e.LockId == lockId) > 0;
        }
    }
}