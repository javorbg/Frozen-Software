using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FrozenSoftware.Models;
using FrozenSoftware.WebApi.Models;

namespace FrozenSoftware.WebApi.Controllers
{
    public class DocumentNumbersController : ApiController
    {
        private FrozenSoftwareWebApiContext db = new FrozenSoftwareWebApiContext();

        // GET: api/DocumentNumbers
        public IQueryable<DocumentNumber> GetDocumentNumbers()
        {
            return db.DocumentNumbers;
        }

        // GET: api/DocumentNumbers/5
        [ResponseType(typeof(DocumentNumber))]
        public async Task<IHttpActionResult> GetDocumentNumber(int id)
        {
            DocumentNumber documentNumber = await db.DocumentNumbers.FindAsync(id);
            if (documentNumber == null)
            {
                return NotFound();
            }

            return Ok(documentNumber);
        }

        // PUT: api/DocumentNumbers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDocumentNumber(int id, DocumentNumber documentNumber)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostDocumentNumber(DocumentNumber documentNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DocumentNumbers.Add(documentNumber);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = documentNumber.Id }, documentNumber);
        }

        // DELETE: api/DocumentNumbers/5
        [ResponseType(typeof(DocumentNumber))]
        public async Task<IHttpActionResult> DeleteDocumentNumber(int id)
        {
            DocumentNumber documentNumber = await db.DocumentNumbers.FindAsync(id);
            if (documentNumber == null)
            {
                return NotFound();
            }

            db.DocumentNumbers.Remove(documentNumber);
            await db.SaveChangesAsync();

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
    }
}