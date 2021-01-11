using Microsoft.EntityFrameworkCore;
using System.Linq;
using Test.Domain.Entities;

namespace Test.Infra.Context
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserSys> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
