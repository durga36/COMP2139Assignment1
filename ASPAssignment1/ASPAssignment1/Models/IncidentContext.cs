using Microsoft.EntityFrameworkCore;

namespace ASPAssignment1.Models
{
    public class IncidentContext : DbContext
    {
        public IncidentContext(DbContextOptions<IncidentContext> options)
              : base(options)
        { }

        public DbSet<Product> Incidents { get; set; }

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

            modelBuilder.Entity<Product>().HasData(
                new Product {ProductId = 1001, Code = "TRNY10", Name = "Tournament Master 1.0", Price = "$4.99", ReleaseDate = "12/1/2015", CategoryId = 1},
                new Product {ProductId = 1002, Code = "LEAG10", Name = "League Scheduler 1.0", Price = "$4.99", ReleaseDate = "5/1/2016", CategoryId = 2},
                new Product {ProductId = 1003, Code = "LEAGD10", Name = "League Scheduler Deluxe 1.0", Price = "$7.99", ReleaseDate = "8/1/2016", CategoryId = 3},
                new Product {ProductId = 1004, Code = "TEAM10", Name = "Team Manager 1.0", Price = "$4.99", ReleaseDate = "5/1/2017", CategoryId = 5},
                new Product { ProductId = 1005, Code = "TEAM10", Name = "Team Manager 1.0", Price = "$4.99", ReleaseDate = "5/1/2017", CategoryId = 5 },
                new Product {ProductId = 1006, Code = "TRNY20", Name = "Tournament Master 2.0", Price = "$5.99", ReleaseDate = "2/15/2018", CategoryId = 1},
                new Product {ProductId = 1007, Code = "DRAFT20", Name = "Draft Manager 2.0", Price = "$5.99", ReleaseDate = "7/15/2019", CategoryId = 4}
            );

            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentId = 4001,
                    Title = "Could not install",
                    Customer = "Kendall Mayte",
                    ProductId = 1004,
                    DateOpened = "1/8/2020",
                    CategoryId = 4
                },

                new Incident
                {
                    IncidentId = 4002,
                    Title = "Could not install",
                    Customer = "Gonzalo Keeton",
                    ProductId = 1001,
                    DateOpened = "1/8/2020",
                    CategoryId = 1
                },

                new Incident
                {
                    IncidentId = 4003,
                    Title = "Error importing data",
                    Customer = "Ania Irvin",
                    ProductId = 1003,
                    DateOpened = "1/9/2020",
                    CategoryId = 4
                },

                new Incident
                {
                    IncidentId = 4004,
                    Title = "Error launching program",
                    Customer = "Kendall Mayte",
                    ProductId = 1003,
                    DateOpened = "1/10/2020",
                    CategoryId = 4
                }
            );
        }
    }
}
