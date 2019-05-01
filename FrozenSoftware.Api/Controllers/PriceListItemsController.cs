using FrozenSoftware.Api.Models;
using FrozenSoftware.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace FrozenSoftware.Api.Controllers
{
    public class PriceListItemsController : ApiController
    {
        private FrozenSoftwareApiContext db = new FrozenSoftwareApiContext();

        // GET: api/PriceListItems
        public IEnumerable<PriceListItem> GetPriceListItems()
        {
            return db.PriceListItems.Include(x => x.Good).Include(x => x.Good.MeasureUnit).ToList();
        }

        // GET: api/PriceListItems/5
        [ResponseType(typeof(PriceListItem))]
        public IHttpActionResult GetPriceListItem(int id)
        {
            PriceListItem priceListItem = db.PriceListItems.Find(id);

            if (priceListItem == null)
            {
                return NotFound();
            }

            return Ok(priceListItem);
        }

        // PUT: api/PriceListItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPriceListItem(int id, PriceListItem priceListItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != priceListItem.Id)
            {
                return BadRequest();
            }

            db.Entry(priceListItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceListItemExists(id))
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

        // POST: api/PriceListItems
        [ResponseType(typeof(PriceListItem))]
        public IHttpActionResult PostPriceListItem(PriceListItem priceListItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PriceListItems.Add(priceListItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = priceListItem.Id }, priceListItem);
        }

        // DELETE: api/PriceListItems/5
        [ResponseType(typeof(PriceListItem))]
        public IHttpActionResult DeletePriceListItem(int id)
        {
            PriceListItem priceListItem = db.PriceListItems.Find(id);
            if (priceListItem == null)
            {
                return NotFound();
            }

            db.PriceListItems.Remove(priceListItem);
            db.SaveChanges();

            return Ok(priceListItem);
        }

        // GET: api/PriceListItems
        public IEnumerable<PriceListItem> GetPriceListItems(int priceListId)
        {
            if (priceListId == 0)
            {
                return null;
            }

            return db.PriceListItems.Where(x => x.PriceListId == priceListId)
                .Include(x => x.Good)
                .Include(x => x.Good.MeasureUnit).ToList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PriceListItemExists(int id)
        {
            return db.PriceListItems.Count(e => e.Id == id) > 0;
        }
    }
}