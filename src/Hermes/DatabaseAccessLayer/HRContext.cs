using Entities;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DatabaseAccessLayer
{
    public class HRContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public HRContext()
            : base("Hermes")
        {
            Database.SetInitializer<HRContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // tables are named the same as entity classes, in the singular
            // e.g. Location, Department
            modelBuilder.Types().Configure(type => type.ToTable(type.ClrType.Name));

            modelBuilder.Conventions.Add<ForeignKeyPropertyIsTableId>();
        }
    }

    public class ForeignKeyPropertyIsTableId : IStoreModelConvention<AssociationType>
    {
        public void Apply(AssociationType association, DbModel model)
        {
            if (association.IsForeignKey)
            {
                foreach (var prop in association.Constraint.ToProperties)
                {
                    // This comes in as Manager_EmployeeId; we set it to ManagerId
                    prop.Name = prop.Name.Substring(0, prop.Name.IndexOf('_')) + "Id";
                }
            }
        }
    }
}
