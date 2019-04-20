using FrozenSoftware.Api.Models;
using FrozenSoftware.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace FrozenSoftware.Api.Controllers
{
    public class PaymentTypesController : ApiController
    {
        private FrozenSoftwareApiContext db = new FrozenSoftwareApiContext();

        // GET: api/PaymentTypes
        public IQueryable<PaymentType> GetPaymentTypes()
        {
            return db.PaymentTypes;
        }

        // GET: api/PaymentTypes/5
        [ResponseType(typeof(PaymentType))]
        public IHttpActionResult GetPaymentType(int id)
        {
            PaymentType paymentType = db.PaymentTypes.Find(id);
            if (paymentType == null)
            {
                return NotFound();
            }

            return Ok(paymentType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentTypeExists(int id)
        {
            return db.PaymentTypes.Count(e => e.Id == id) > 0;
        }
    }
}