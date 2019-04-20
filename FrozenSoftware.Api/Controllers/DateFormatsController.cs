using FrozenSoftware.Api.Models;
using FrozenSoftware.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace FrozenSoftware.Api.Controllers
{
    public class DateFormatsController : ApiController
    {
        private FrozenSoftwareApiContext db = new FrozenSoftwareApiContext();

        // GET: api/DateFormats
        public IQueryable<DateFormat> GetDateFormats()
        {
            return db.DateFormats;
        }

        // GET: api/DateFormats/5
        [ResponseType(typeof(DateFormat))]
        public IHttpActionResult GetDateFormat(int id)
        {
            DateFormat dateFormat = db.DateFormats.Find(id);
            if (dateFormat == null)
            {
                return NotFound();
            }

            return Ok(dateFormat);
        }

        // PUT: api/DateFormats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDateFormat(int id, DateFormat dateFormat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dateFormat.Id)
            {
                return BadRequest();
            }

            db.Entry(dateFormat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DateFormatExists(id))
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

        // POST: api/DateFormats
        [ResponseType(typeof(DateFormat))]
        public IHttpActionResult PostDateFormat(DateFormat dateFormat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DateFormats.Add(dateFormat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dateFormat.Id }, dateFormat);
        }

        // DELETE: api/DateFormats/5
        [ResponseType(typeof(DateFormat))]
        public IHttpActionResult DeleteDateFormat(int id)
        {
            DateFormat dateFormat = db.DateFormats.Find(id);
            if (dateFormat == null)
            {
                return NotFound();
            }

            db.DateFormats.Remove(dateFormat);
            db.SaveChanges();

            return Ok(dateFormat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DateFormatExists(int id)
        {
            return db.DateFormats.Count(e => e.Id == id) > 0;
        }
    }
}