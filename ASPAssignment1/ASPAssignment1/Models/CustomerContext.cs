using Microsoft.EntityFrameworkCore;

namespace ASPAssignment1.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
              : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

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

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 3001,
                    Name = "Kaitlyn Anthoni",
                    Email = "kanthoni@pge.com",
                    City = "San Francisco",
                },

                new Customer
                {
                    CustomerId = 3002,
                    Name = "Ania Irvin",
                    Email = "ania@mma.nidc.com",
                    City = "Washington",
                },

                new Customer
                {
                    CustomerId = 3003,
                    Name = "Gonzalo Keeton",
                    Email = "",
                    City = "Mission Viejo",
                },

                new Customer
                {
                    CustomerId = 3004,
                    Name = "Anton Mauro",
                    Email = "amauro@yahoo.org",
                    City = "Sacramento",
                },

                new Customer
                {
                    CustomerId = 3005,
                    Name = "Kendall Mayte",
                    Email = "kmayte@fresno.ca.gov",
                    City = "Fresno",
                },

                new Customer
                {
                    CustomerId = 3006,
                    Name = "Kenzie Quinn",
                    Email = "kenzie@mma.jobtrak.com",
                    City = "Los Angeles",
                },

                new Customer
                {
                    CustomerId = 3007,
                    Name = "Marvin Quintin",
                    Email = "marvin@expedata.com",
                    City = "Fresno",
                }
            );
        }
    }
}
