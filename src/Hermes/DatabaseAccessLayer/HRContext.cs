using Entities;
using System.Data.Entity;

namespace DatabaseAccessLayer
{
    public class HRContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        public HRContext()
            : base("Hermes")
        {
            Database.SetInitializer<HRContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(type => type.ToTable(type.ClrType.Name));
        }
    }
}
