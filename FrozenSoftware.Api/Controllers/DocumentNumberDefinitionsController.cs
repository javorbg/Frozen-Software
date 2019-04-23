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
    public class DocumentNumberDefinitionsController : ApiController
    {
        private FrozenSoftwareApiContext db = new FrozenSoftwareApiContext();

        // GET: api/DocumentNumberDefinitions
        public IQueryable<DocumentNumberDefinition> GetDocumentNumberDefinitions()
        {
            return db.DocumentNumberDefinitions;
        }

        // GET: api/DocumentNumberDefinitions/5
        [ResponseType(typeof(DocumentNumberDefinition))]
        public IHttpActionResult GetDocumentNumberDefinition(int id)
        {
            DocumentNumberDefinition documentNumberDefinition = db.DocumentNumberDefinitions.Find(id);
            if (documentNumberDefinition == null)
            {
                return NotFound();
            }

            return Ok(documentNumberDefinition);
        }

        // PUT: api/DocumentNumberDefinitions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocumentNumberDefinition(int id, DocumentNumberDefinition documentNumberDefinition)
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
                db.SaveChanges();
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
        public IHttpActionResult PostDocumentNumberDefinition(DocumentNumberDefinition documentNumberDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DocumentNumberDefinitions.Add(documentNumberDefinition);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = documentNumberDefinition.Id }, documentNumberDefinition);
        }

        // DELETE: api/DocumentNumberDefinitions/5
        [ResponseType(typeof(DocumentNumberDefinition))]
        public IHttpActionResult DeleteDocumentNumberDefinition(int id)
        {
            DocumentNumberDefinition documentNumberDefinition = db.DocumentNumberDefinitions.Find(id);
            if (documentNumberDefinition == null)
            {
                return NotFound();
            }

            db.DocumentNumberDefinitions.Remove(documentNumberDefinition);
            db.SaveChanges();

            return Ok(documentNumberDefinition);
        }

        [HttpPut]
        [ResponseType(typeof(bool))]
        [Route("api/DocumentNumberDefinitions/{id}/{lockId}")]
        public IHttpActionResult LockEntity(int id, Guid lockId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id < 1)
            {
                return BadRequest();
            }

            EntityBase lockEntity = db.DocumentNumberDefinitions.Find(id);

            if (lockEntity == null)
            {
                return NotFound();
            }

            if (lockEntity.LockId != null)
                return Ok(false);

            lockEntity.LockId = lockId;

            try
            {
                db.SaveChanges();

                return Ok(true);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityLockIdExists(lockId))
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
        }

        [HttpPut]
        [ResponseType(typeof(bool))]
        [Route("api/DocumentNumberDefinitions/Unlock/{id}/{lockId}")]
        public IHttpActionResult UnlockEntity(int id, Guid lockId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id < 1)
            {
                return BadRequest();
            }

            EntityBase lockEntity = db.DocumentNumberDefinitions.Find(id);

            if (lockEntity == null)
            {
                return NotFound();
            }

            if (lockEntity.LockId != null && lockEntity.LockId == lockId)
            {
                lockEntity.LockId = null;
            }

            try
            {
                db.SaveChanges();

                return Ok(true);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityLockIdExists(lockId))
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
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

        private bool EntityLockIdExists(Guid lockId)
        {
            return db.DocumentNumberDefinitions.Count(e => e.LockId == lockId) > 0;
        }
    }
}