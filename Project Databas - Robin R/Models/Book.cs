using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Databas___Robin_R.Models
{
    internal class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int Isbn { get; set; }
        public string Author { get; set; }

        public int Rating { get; set; }

        public bool IsRented { get; set; }

        public DateTime? DateOfLoan { get; set; }
        public DateTime? DateOfReturn { get; set; }

        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();


        public Book()
        {
            
        }

    }
}
