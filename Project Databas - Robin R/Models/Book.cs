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
        public string BookTitle { get; set; }
        public int ReleaseDate { get; set; }
        public int Isbn { get; set; }
        public string Author { get; set; }

        public int Rating { get; set; }

        public Book()
        {
            
        }

    }
}
