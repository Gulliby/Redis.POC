using Data.Entities;
using System.Data.Entity;
using Data.Mapping;

namespace Data
{
    public class CustomDbContext : DbContext
    {
        public CustomDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<CountryDb> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Configurations.Add(new CountriesMapping());
            modelBuilder.Configurations.Add(new CodesMapping());
        }
    }
}
