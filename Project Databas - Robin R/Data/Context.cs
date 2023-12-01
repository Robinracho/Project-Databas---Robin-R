using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_Databas___Robin_R.Models;

namespace Project_Databas___Robin_R.Data
{
    internal class Context: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Library> Libraries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Server=localhost;
                Database=NewtonLibrary Robin;
                Trusted_Connection=True;
                Trust Server Certificate=Yes;
                User Id=NewtonLibrary;
                password=NewtonLibrary");
        }
    }
}
