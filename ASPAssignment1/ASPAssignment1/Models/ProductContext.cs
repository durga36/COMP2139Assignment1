using Microsoft.EntityFrameworkCore;

namespace ASPAssignment1.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
              : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Tournament Master" },
                new Category { CategoryId = 2, CategoryName = "League Scheduler" },
                new Category { CategoryId = 3, CategoryName = "League Scheduler Deluxe" },
                new Category { CategoryId = 4, CategoryName = "Draft Manager" },
                new Category { CategoryId = 5, CategoryName = "Team Manager"}
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1001,
                    Code = "TRNY10",
                    Name = "Tournament Master 1.0",
                    Price = "$4.99",
                    ReleaseDate = "12/1/2015",
                    CategoryId = 1
                },

                new Product
                {
                    ProductId = 1002,
                    Code = "LEAG10",
                    Name = "League Scheduler 1.0",
                    Price = "$4.99",
                    ReleaseDate = "5/1/2016",
                    CategoryId = 2
                },

                new Product
                {
                    ProductId = 1003,
                    Code = "LEAGD10",
                    Name = "League Scheduler Deluxe 1.0",
                    Price = "$7.99",
                    ReleaseDate = "8/1/2016",
                    CategoryId = 3
                },

                new Product
                {
                    ProductId = 1004,
                    Code = "DRAFT10",
                    Name = "Draft Manager 1.0",
                    Price = "$4.99",
                    ReleaseDate = "2/1/2017",
                    CategoryId = 4
                },

                new Product
                {
                    ProductId = 1005,
                    Code = "TEAM10",
                    Name = "Team Manager 1.0",
                    Price = "$4.99",
                    ReleaseDate = "5/1/2017",
                    CategoryId = 5
                },

                new Product
                {
                    ProductId = 1006,
                    Code = "TRNY20",
                    Name = "Tournament Master 2.0",
                    Price = "$5.99",
                    ReleaseDate = "2/15/2018",
                    CategoryId = 1
                },

                new Product
                {
                    ProductId = 1007,
                    Code = "DRAFT20",
                    Name = "Draft Manager 2.0",
                    Price = "$5.99",
                    ReleaseDate = "7/15/2019",
                    CategoryId = 4
                }
            );
        }
    }
}
