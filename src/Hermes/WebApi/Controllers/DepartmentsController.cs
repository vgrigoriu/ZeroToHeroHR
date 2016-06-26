using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using DatabaseAccessLayer;
using Entities;
using System.Data.Entity;

namespace WebApi.Controllers
{
    public class DepartmentsController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var db = new HRContext())
            {
                return Ok(db.Departments.Include(dep => dep.Location).ToList());
            }
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            using (var db = new HRContext())
            {
                var department = await db.Departments
                    .Include(dep => dep.Location)
                    .SingleOrDefaultAsync(dep => dep.DepartmentId == id);

                if (department == null)
                {
                    return NotFound();
                }

                return Ok(department);
            }
        }

        public async Task<IHttpActionResult> Post(Department department)
        {
            // todo: validation
            // todo: id should not be client-generated

            using (var db = new HRContext())
            {
                // don't insert a new location, use the existing one
                db.Entry(department.Location).State = EntityState.Unchanged;

                db.Departments.Add(department);

                await db.SaveChangesAsync();

                return Created($"departments/{department.DepartmentId}", department);
            }
        }

        //public async Task<IHttpActionResult> Put(Job job)
        //{
        //    using (var db = new HRContext())
        //    {
        //        var existingJob = await db.Jobs.FindAsync(job.JobId);

        //        if (existingJob == null)
        //        {
        //            return NotFound();
        //        }

        //        existingJob.JobTitle = job.JobTitle;
        //        existingJob.MinSalary = job.MinSalary;
        //        existingJob.MaxSalary = job.MaxSalary;

        //        await db.SaveChangesAsync();

        //        return Ok(existingJob);
        //    }
        //}

        //public async Task<IHttpActionResult> Delete(string id)
        //{
        //    using (var db = new HRContext())
        //    {
        //        var existingJob = await db.Jobs.FindAsync(id);

        //        if (existingJob == null)
        //        {
        //            return NotFound();
        //        }

        //        db.Jobs.Remove(existingJob);
        //        await db.SaveChangesAsync();

        //        return Ok();
        //    }
        //}
    }
}