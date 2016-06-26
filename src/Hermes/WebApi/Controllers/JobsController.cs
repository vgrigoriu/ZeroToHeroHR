using DatabaseAccessLayer;
using Entities;
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

        public async Task<IHttpActionResult> Post(Job job)
        {
            // todo: validation

            using (var db = new HRContext())
            {
                db.Jobs.Add(job);

                await db.SaveChangesAsync();

                return Created($"jobs/{job.JobId}", job);
            }
        }

        public async Task<IHttpActionResult> Put(Job job)
        {
            using (var db = new HRContext())
            {
                var existingJob = await db.Jobs.FindAsync(job.JobId);

                if (existingJob == null)
                {
                    return NotFound();
                }

                existingJob.JobTitle = job.JobTitle;
                existingJob.MinSalary = job.MinSalary;
                existingJob.MaxSalary = job.MaxSalary;

                await db.SaveChangesAsync();

                return Ok(existingJob);
            }
        }

        public async Task<IHttpActionResult> Delete(string id)
        {
            using (var db = new HRContext())
            {
                var existingJob = await db.Jobs.FindAsync(id);

                if (existingJob == null)
                {
                    return NotFound();
                }

                db.Jobs.Remove(existingJob);
                await db.SaveChangesAsync();

                return Ok();
            }
        }
    }
}
