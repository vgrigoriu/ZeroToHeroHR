using DatabaseAccessLayer;
using System.Linq;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class JobsController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var db = new HRContext())
            {
                return Ok(db.Jobs.ToList());
            }
        }
    }
}
