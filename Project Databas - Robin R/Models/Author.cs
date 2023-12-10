using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Databas___Robin_R.Models
{
    internal class Author
    {

        public int AuthorID { get; set; } //Primary Key
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}

