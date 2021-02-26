using Microsoft.EntityFrameworkCore;

namespace ASPAssignment1.Models
{
    public class TechnicianContext : DbContext
    {
        public TechnicianContext(DbContextOptions<TechnicianContext> options)
              : base(options)
        { }

        public DbSet<Technician> Technicians { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Tournament Master" },
                new Category { CategoryId = 2, CategoryName = "League Scheduler" },
                new Category { CategoryId = 3, CategoryName = "League Scheduler Deluxe" },
                new Category { CategoryId = 4, CategoryName = "Draft Manager" },
                new Category { CategoryId = 5, CategoryName = "Team Manager" }
            );

            modelBuilder.Entity<Technician>().HasData(
                new Technician
                {
                    TechnicianId = 2001,
                    Name = "Alison Diaz",
                    Email = "alison@sportsprosoftware.com",
                    Phone = "800-555-0443"
                },

                new Technician
                {
                    TechnicianId = 2002,
                    Name = "Andrew Wilson",
                    Email = "awilson@sportsprosoftware.com",
                    Phone = "800-555-0449"
                },

                new Technician
                {
                    TechnicianId = 2003,
                    Name = "Gina Fiori",
                    Email = "gfiori@sportsprosoftware.com",
                    Phone = "800-555-0459"
                },

                new Technician
                {
                    TechnicianId = 2004,
                    Name = "Gunter Wendt",
                    Email = "gunter@sportsprosoftware.com",
                    Phone = "800-555-0400"
                },

                new Technician
                {
                    TechnicianId = 2005,
                    Name = "Jason Lee",
                    Email = "jason@sportsprosoftware.com",
                    Phone = "800-555-0444"
                }
            );
        }
    }
}
