using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Databas___Robin_R.Models
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CardID { get; set; }

        public int CardPin { get; set; }
        public ICollection<Book> BooksBorrowed { get; set; } = new List<Book>();
        public Customer()
        {
            
        }

    }
}
