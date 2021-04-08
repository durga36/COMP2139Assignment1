using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ASPAssignment1.Models
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions<CustomerContext> options)
              : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Genre> Products { get; set; }
        public object Conference { get; internal set; }
        public object Divisions { get; internal set; }
        public IQueryable<Registration> Registrations { get; internal set; }
        public object Registration { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
