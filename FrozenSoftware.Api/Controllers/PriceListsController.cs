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
    public class PriceListsController : ApiController
    {
        private FrozenSoftwareApiContext db = new FrozenSoftwareApiContext();

        // GET: api/PriceLists
        public IQueryable<PriceList> GetPriceLists()
        {
            return db.PriceLists;
        }

        // GET: api/PriceLists/5
        [ResponseType(typeof(PriceList))]
        public IHttpActionResult GetPriceList(int id)
        {
            PriceList priceList = db.PriceLists.Find(id);
            if (priceList == null)
            {
                return NotFound();
            }

            return Ok(priceList);
        }
    
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPriceList(int id, [FromBody] PriceListJson priceListJson)
        {
            if (priceListJson == null || priceListJson.PriceList == null || priceListJson.PriceList.Id < 1)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != priceListJson.PriceList.Id)
            {
                return BadRequest();
            }

            db.Entry(priceListJson.PriceList).State = EntityState.Modified;

            if (priceListJson.PriceListItems != null && priceListJson.PriceListItems.Count > 0)
            {
                foreach (PriceListItem priceListItem in priceListJson.PriceListItems)
                {
                    db.Entry(priceListItem).State = EntityState.Modified;
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceListExists(id))
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

        // POST: api/PriceLists
        [ResponseType(typeof(PriceList))]
        public IHttpActionResult PostPriceList([FromBody]PriceListJson priceListJson)
        {
            if (priceListJson == null || priceListJson.PriceList == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PriceLists.Add(priceListJson.PriceList);

            if (priceListJson.PriceListItems != null && priceListJson.PriceListItems.Count > 0)
            {
                foreach (var item in priceListJson.PriceListItems)
                {
                    item.PriceList = priceListJson.PriceList;
                    db.PriceListItems.Add(item);
                }
            }

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = priceListJson.PriceList.Id }, priceListJson.PriceList);
        }

        // DELETE: api/PriceLists/5
        [ResponseType(typeof(PriceList))]
        public IHttpActionResult DeletePriceList(int id)
        {
            PriceList priceList = db.PriceLists.Find(id);
            if (priceList == null)
            {
                return NotFound();
            }

            db.PriceLists.Remove(priceList);
            db.SaveChanges();

            return Ok(priceList);
        }

        [HttpPut]
        [ResponseType(typeof(bool))]
        [Route("api/PriceLists/Lock/{id}/{lockId}")]
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

            EntityBase lockEntity = db.PriceLists.Find(id);

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
        [Route("api/PriceLists/Unlock/{id}/{lockId}")]
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

            EntityBase lockEntity = db.PriceLists.Find(id);

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

        private bool PriceListExists(int id)
        {
            return db.PriceLists.Count(e => e.Id == id) > 0;
        }

        private bool EntityLockIdExists(Guid lockId)
        {
            return db.PriceLists.Count(e => e.LockId == lockId) > 0;
        }
    }
}