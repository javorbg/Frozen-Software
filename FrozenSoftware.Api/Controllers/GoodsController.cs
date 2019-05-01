using FrozenSoftware.Api.Models;
using FrozenSoftware.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace FrozenSoftware.Api.Controllers
{
    public class GoodsController : ApiController
    {
        private FrozenSoftwareApiContext db = new FrozenSoftwareApiContext();

        // GET: api/Goods
        public IEnumerable<Good> GetGoods()
        {
            return db.Goods.Include(x => x.MeasureUnit).ToList();
        }

        // GET: api/Goods/5
        [ResponseType(typeof(Good))]
        public IHttpActionResult GetGood(int id)
        {
            Good good = db.Goods.Find(id);
            if (good == null)
            {
                return NotFound();
            }

            return Ok(good);
        }

        [HttpGet]
        [Route("api/Goods/Count")]
        public int GetGoodCount()
        {
            string countName = $"select COUNT(*) from {nameof(db.Goods)}";

            return db.Database.SqlQuery<int>(countName).FirstOrDefault();
        }

        // PUT: api/Goods/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGood(int id, Good good)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != good.Id)
            {
                return BadRequest();
            }

            db.Entry(good).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodExists(id))
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

        // POST: api/Goods
        [ResponseType(typeof(Good))]
        public IHttpActionResult PostGood(Good good)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Goods.Add(good);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = good.Id }, good);
        }

        // DELETE: api/Goods/5
        [ResponseType(typeof(Good))]
        public IHttpActionResult DeleteGood(int id)
        {
            Good good = db.Goods.Find(id);
            if (good == null)
            {
                return NotFound();
            }

            db.Goods.Remove(good);
            db.SaveChanges();

            return Ok(good);
        }

        [HttpPut]
        [ResponseType(typeof(bool))]
        [Route("api/Goods/Lock/{id}/{lockId}")]
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

            EntityBase lockEntity = db.Goods.Find(id);

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
        [Route("api/Goods/Unlock/{id}/{lockId}")]
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

            EntityBase lockEntity = db.Goods.Find(id);

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

        private bool GoodExists(int id)
        {
            return db.Goods.Count(e => e.Id == id) > 0;
        }

        private bool EntityLockIdExists(Guid lockId)
        {
            return db.Goods.Count(e => e.LockId == lockId) > 0;
        }
    }
}