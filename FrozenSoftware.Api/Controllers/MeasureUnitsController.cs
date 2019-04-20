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
    public class MeasureUnitsController : ApiController
    {
        private FrozenSoftwareApiContext db = new FrozenSoftwareApiContext();

        // GET: api/MeasureUnits
        public IQueryable<MeasureUnit> GetMeasureUnits()
        {
            return db.MeasureUnits;
        }

        // GET: api/MeasureUnits/5
        [ResponseType(typeof(MeasureUnit))]
        public IHttpActionResult GetMeasureUnit(int id)
        {
            MeasureUnit measureUnit = db.MeasureUnits.Find(id);
            if (measureUnit == null)
            {
                return NotFound();
            }

            return Ok(measureUnit);
        }

        // PUT: api/MeasureUnits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeasureUnit(int id, MeasureUnit measureUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != measureUnit.Id)
            {
                return BadRequest();
            }

            db.Entry(measureUnit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasureUnitExists(id))
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

        // POST: api/MeasureUnits
        [ResponseType(typeof(MeasureUnit))]
        public IHttpActionResult PostMeasureUnit(MeasureUnit measureUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MeasureUnits.Add(measureUnit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = measureUnit.Id }, measureUnit);
        }

        [HttpPut]
        [ResponseType(typeof(bool))]
        public IHttpActionResult LockLockEntity(int id, Guid lockId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id < 1)
            {
                return BadRequest();
            }

            EntityBase lockEntity = db.MeasureUnits.Find(id);

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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeasureUnitExists(int id)
        {
            return db.MeasureUnits.Count(e => e.Id == id) > 0;
        }

        private bool EntityLockIdExists(Guid lockId)
        {
            return db.MeasureUnits.Count(e => e.LockId == lockId) > 0;
        }
    }
}