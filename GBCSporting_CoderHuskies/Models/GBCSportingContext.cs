using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting_CoderHuskies.Models
{
    public class GBCSportingContext : DbContext
    {

        public GBCSportingContext(DbContextOptions<GBCSportingContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }

        public DbSet<Technician> Technician { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Incident> Incident { get; set; }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Code = "TRNY10",
                    Name = "Trournament Master 1.0",
                    Price = 4.99,
                    Date = new DateTime(2015, 12, 1)
                },
                new Product
                {
                    ProductId = 2,
                    Code = "LEAG10",
                    Name = "League Scheduler 1.0",
                    Price = 4.99,
                    Date = new DateTime(2016, 6, 1)
                },
                new Product
                {
                    ProductId = 3,
                    Code = "DRAFT10",
                    Name = "Draft Manager 1.0",
                    Price = 5.99,
                    Date = new DateTime(2017, 11, 7)
                },
                new Product
                {
                    ProductId = 4,
                    Code = "TEAM10",
                    Name = "Team Manager 1.0",
                    Price = 7.99,
                    Date = new DateTime(2015, 4, 20)
                }
                );

            ModelBuilder.Entity<Technician>().HasData(
                new Technician
                {
                    TechnicianId = 1,
                    Name = "Jason Chang",
                    Email = "jasonc@sportspro.com",
                    Phone = "416-987-6543"
                },
                new Technician
                {
                    TechnicianId = 2,
                    Name = "Chris Senior",
                    Email = "csenior@sportspro.com",
                    Phone = "647-123-4567"
                },
                new Technician
                {
                    TechnicianId = 3,
                    Name = "John McDonald",
                    Email = "johnmc@sportspro.com",
                    Phone = "902-456-7890"
                },
                new Technician
                {
                    TechnicianId = 4,
                    Name = "Alison Diaz",
                    Email = "alison@sportspro.com",
                    Phone = "902-456-7890"
                },
                new Technician
                {
                    TechnicianId = 5,
                    Name = "Gina Fiori",
                    Email = "gfiori@sportspro.com",
                    Phone = "902-456-7890"
                }
                );

            ModelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Kevin",
                    LastName = "Smith",
                    Address = "5 Concord Place",
                    City = "North York",
                    State = "Ontario",
                    PostalCode = "M16 8J9",
                    CountryId = "CAN",
                    Email = "ksmith98@gmail.com",
                    Phone = null
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Jerry",
                    LastName = "Patel",
                    Address = "A-501 Nirman Tower",
                    City = "Ahmedabad",
                    State = "Gujarat",
                    PostalCode = "380005",
                    CountryId = "IND",
                    Email = null,
                    Phone = "9727243403"
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Jacob",
                    LastName = "Rogers",
                    Address = "145 Queens street",
                    City = "Toronto",
                    State = "Ontario",
                    PostalCode = "M25 8F7",
                    CountryId = "CAN",
                    Email = "jacob1758@gmail.com",
                    Phone = "416-321-4567"
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Address = "698 Flash Avenue",
                    City = "New York",
                    State = "New York",
                    PostalCode = "NY 10024",
                    CountryId = "USA",
                    Email = null,
                    Phone = null
                },
                new Customer
                {
                    CustomerId = 5,
                    FirstName = "John",
                    LastName = "Stuart",
                    Address = "2616 Mason Heights",
                    City = "Mississauga",
                    State = "Ontario",
                    PostalCode = "L5B 2S2",
                    CountryId = "CAN",
                    Email = "stuartj007@gmail.com",
                    Phone = null
                }
                );

            ModelBuilder.Entity<Country>().HasData(
                new Country { CountryId = "AUS", Name = "Australia" },
                new Country { CountryId = "BRA", Name = "Brazil" },
                new Country { CountryId = "CAN", Name = "Canada" },
                new Country { CountryId = "CHN", Name = "China" },
                new Country { CountryId = "EGY", Name = "Egypt" },
                new Country { CountryId = "FRA", Name = "France" },
                new Country { CountryId = "IND", Name = "India" },
                new Country { CountryId = "ARE", Name = "United Arab Emirates" },
                new Country { CountryId = "GBR", Name = "United Kingdom of Great Britain and Northern Ireland" },
                new Country { CountryId = "USA", Name = "United States of America" }
                );

            ModelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentId = 1,
                    CustomerId = 2,
                    ProductId = 2,
                    Title = "Could Not Install",
                    Description = "Giving error while accepting terms and condition",
                    TechnicianId = 5,
                    DateOpened = new DateTime(2021, 11, 20),
                    DateClosed = new DateTime(2021, 12, 8)
                },
                new Incident
                {
                    IncidentId = 2,
                    CustomerId = 1,
                    ProductId = 1,
                    Title = "Error importing data",
                    Description = "Gives Error while importing data from CSV file.",
                    TechnicianId = 3,
                    DateOpened = null,
                    DateClosed = new DateTime(2021, 8, 25)
                },
                new Incident
                {
                    IncidentId = 3,
                    CustomerId = 4,
                    ProductId = 4,
                    Title = "Error launching program",
                    Description = "Gives error on launching saying - 'Cannot Connect To Database'",
                    TechnicianId = 1,
                    DateOpened = new DateTime(2021, 4, 25),
                    DateClosed = new DateTime(2021, 6, 5)
                },
                new Incident
                {
                    IncidentId = 4,
                    CustomerId = 3,
                    ProductId = 3,
                    Title = "Could Not Install",
                    Description = "Installer launches and immidiately",
                    TechnicianId = 2,
                    DateOpened = null,
                    DateClosed = new DateTime(2020, 11, 15)
                }
                );

        }

    }
}
