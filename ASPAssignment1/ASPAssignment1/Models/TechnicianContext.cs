using Microsoft.EntityFrameworkCore;

namespace ASPAssignment1.Models
{
    public class TechnicianContext : DbContext
    {
        public TechnicianContext(DbContextOptions<TechnicianContext> options)
              : base(options)
        { }

        public DbSet<Technician> Technicians { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public object Conferences { get; internal set; }
        public object Divisions { get; internal set; }
        public object Conference { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
               new Genre { GenreId = "ToM", Name = "Tournament Master" },
               new Genre { GenreId = "LS", Name = "League Scheduler" },
               new Genre { GenreId = "LSD", Name = "League Scheduler Deluxe" },
               new Genre { GenreId = "DM", Name = "Draft Manager" },
               new Genre { GenreId = "TeM", Name = "Team Manager" }
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
