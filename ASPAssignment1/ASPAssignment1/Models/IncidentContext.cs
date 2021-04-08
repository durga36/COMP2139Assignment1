using Microsoft.EntityFrameworkCore;

namespace ASPAssignment1.Models
{
    public class IncidentContext : DbContext
    {
        public IncidentContext(DbContextOptions<IncidentContext> options)
              : base(options)
        { }

        public DbSet<Incident> Incidents { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
               new Genre { GenreId = "ToM", Name = "Tournament Master" },
               new Genre { GenreId = "LS", Name = "League Scheduler" },
               new Genre { GenreId = "LSD", Name = "League Scheduler Deluxe" },
               new Genre { GenreId = "DM", Name = "Draft Manager" },
               new Genre { GenreId = "TeM", Name = "Team Manager" }
           );

            modelBuilder.Entity<Product>().HasData(
                new Product {ProductId = 1001, Code = "TRNY10", Name = "Tournament Master 1.0", Price = "$4.99", ReleaseDate = "12/1/2015", GenreId = "ToM"},
                new Product {ProductId = 1002, Code = "LEAG10", Name = "League Scheduler 1.0", Price = "$4.99", ReleaseDate = "5/1/2016", GenreId = "LS"},
                new Product {ProductId = 1003, Code = "LEAGD10", Name = "League Scheduler Deluxe 1.0", Price = "$7.99", ReleaseDate = "8/1/2016", GenreId = "LSD"},
                new Product {ProductId = 1004, Code = "TEAM10", Name = "Team Manager 1.0", Price = "$4.99", ReleaseDate = "5/1/2017", GenreId = "TeM"},
                new Product { ProductId = 1005, Code = "TEAM10", Name = "Team Manager 1.0", Price = "$4.99", ReleaseDate = "5/1/2017", GenreId = "TeM"},
                new Product {ProductId = 1006, Code = "TRNY20", Name = "Tournament Master 2.0", Price = "$5.99", ReleaseDate = "2/15/2018", GenreId = "ToM"},
                new Product {ProductId = 1007, Code = "DRAFT20", Name = "Draft Manager 2.0", Price = "$5.99", ReleaseDate = "7/15/2019", GenreId = "DM"}
            );

            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentId = 4001,
                    Title = "Could not install",
                    Customer = "Kendall Mayte",
                    DateOpened = "1/8/2020",
                    GenreId = "DM"
                },

                new Incident
                {
                    IncidentId = 4002,
                    Title = "Could not install",
                    Customer = "Gonzalo Keeton",
                    DateOpened = "1/8/2020",
                    GenreId = "ToM"
                },

                new Incident
                {
                    IncidentId = 4003,
                    Title = "Error importing data",
                    Customer = "Ania Irvin",
                    DateOpened = "1/9/2020",
                    GenreId = "LSD"
                },

                new Incident
                {
                    IncidentId = 4004,
                    Title = "Error launching program",
                    Customer = "Kendall Mayte",
                    DateOpened = "1/10/2020",
                    GenreId = "LSD"
                }
            );
        }
    }
}
