using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Databas___Robin_R.Models
{
    internal class Library
    {
        public int ID { get; set; }
        public string Name { get; set; }
     
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public Library()
        {
            
        }
    }
}
