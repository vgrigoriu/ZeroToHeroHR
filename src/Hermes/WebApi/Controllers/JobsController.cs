using DatabaseAccessLayer;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IHttpActionResult> Get(string id)
        {
            using (var db = new HRContext())
            {
                var job = await db.Jobs.FindAsync(id);

                if (job == null)
                {
                    return NotFound();
                }

                return Ok(job);
            }
        }
    }
}
