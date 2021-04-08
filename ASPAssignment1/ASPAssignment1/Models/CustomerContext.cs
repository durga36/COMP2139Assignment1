using Microsoft.EntityFrameworkCore;

namespace ASPAssignment1.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
              : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public object Conference { get; internal set; }
        public object Divisions { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
               new Genre { GenreId = "ToM", Name = "Tournament Master" },
               new Genre { GenreId = "LS", Name = "League Scheduler" },
               new Genre { GenreId = "LSD", Name = "League Scheduler Deluxe" },
               new Genre { GenreId = "DM", Name = "Draft Manager" },
               new Genre { GenreId = "TeM", Name = "Team Manager" }
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
