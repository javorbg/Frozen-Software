using FrozenSoftware.Api.Models;
using FrozenSoftware.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace FrozenSoftware.Api.Controllers
{
    public class DocumentStatusController : ApiController
    {
        private FrozenSoftwareApiContext db = new FrozenSoftwareApiContext();

        // GET: api/DocumentStatus
        public IQueryable<DocumentStatus> GetDocumentStatus()
        {
            return db.DocumentStatus;
        }

        // GET: api/DocumentStatus/5
        [ResponseType(typeof(DocumentStatus))]
        public IHttpActionResult GetDocumentStatus(int id)
        {
            DocumentStatus documentStatus = db.DocumentStatus.Find(id);
            if (documentStatus == null)
            {
                return NotFound();
            }

            return Ok(documentStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentStatusExists(int id)
        {
            return db.DocumentStatus.Count(e => e.Id == id) > 0;
        }
    }
}