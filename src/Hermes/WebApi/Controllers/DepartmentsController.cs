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

        public async Task<IHttpActionResult> Put(Department department)
        {
            using (var db = new HRContext())
            {
                var existingDepartment = await db.Departments.FindAsync(department.DepartmentId);

                if (existingDepartment == null)
                {
                    return NotFound();
                }

                // we can only rename departments, not move them to a different location
                existingDepartment.DepartmentName = department.DepartmentName;

                await db.SaveChangesAsync();

                return Ok(existingDepartment);
            }
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            using (var db = new HRContext())
            {
                var existingDepartment = await db.Departments.FindAsync(id);

                if (existingDepartment == null)
                {
                    return NotFound();
                }

                // todo: handle employees from this department
                db.Departments.Remove(existingDepartment);
                await db.SaveChangesAsync();

                return Ok();
            }
        }
    }
}