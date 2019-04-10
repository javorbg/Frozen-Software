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
    public class DocumentNumberDefinitionsController : ApiController
    {
        private FrozenSoftwareWebApiContext db = new FrozenSoftwareWebApiContext();

        // GET: api/DocumentNumberDefinitions
        public IQueryable<DocumentNumberDefinition> GetDocumentNumberDefinitions()
        {
            return db.DocumentNumberDefinitions;
        }

        // GET: api/DocumentNumberDefinitions/5
        [ResponseType(typeof(DocumentNumberDefinition))]
        public async Task<IHttpActionResult> GetDocumentNumberDefinition(int id)
        {
            DocumentNumberDefinition documentNumberDefinition = await db.DocumentNumberDefinitions.FindAsync(id);
            if (documentNumberDefinition == null)
            {
                return NotFound();
            }

            return Ok(documentNumberDefinition);
        }

        // PUT: api/DocumentNumberDefinitions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDocumentNumberDefinition(int id, DocumentNumberDefinition documentNumberDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentNumberDefinition.Id)
            {
                return BadRequest();
            }

            db.Entry(documentNumberDefinition).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentNumberDefinitionExists(id))
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

        // POST: api/DocumentNumberDefinitions
        [ResponseType(typeof(DocumentNumberDefinition))]
        public async Task<IHttpActionResult> PostDocumentNumberDefinition(DocumentNumberDefinition documentNumberDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DocumentNumberDefinitions.Add(documentNumberDefinition);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = documentNumberDefinition.Id }, documentNumberDefinition);
        }

        // DELETE: api/DocumentNumberDefinitions/5
        [ResponseType(typeof(DocumentNumberDefinition))]
        public async Task<IHttpActionResult> DeleteDocumentNumberDefinition(int id)
        {
            DocumentNumberDefinition documentNumberDefinition = await db.DocumentNumberDefinitions.FindAsync(id);
            if (documentNumberDefinition == null)
            {
                return NotFound();
            }

            db.DocumentNumberDefinitions.Remove(documentNumberDefinition);
            await db.SaveChangesAsync();

            return Ok(documentNumberDefinition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentNumberDefinitionExists(int id)
        {
            return db.DocumentNumberDefinitions.Count(e => e.Id == id) > 0;
        }
    }
}