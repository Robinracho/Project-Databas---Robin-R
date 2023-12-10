using Microsoft.EntityFrameworkCore;
using Project_Databas___Robin_R.Models;
using System.Collections.Generic;

namespace Project_Databas___Robin_R.Data
{
    internal class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Loan> Loans { get; set; }

        // Database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Localhost;Database=NewtonLibraryRobin;Trusted_Connection=True;TrustServerCertificate=True;User Id=NewtonLibrary;Password=NewtonLibrary");

        }


    }
}
