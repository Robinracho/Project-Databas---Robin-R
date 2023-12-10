using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Databas___Robin_R.Models
{
    internal class Loan
    {
        public int BookID { get; set; } //Foreign Key 

        public int LoanID { get; set; } //Primary Key

        public int CustomerID { get; set; } //Foreign Key

        public DateTime? DateOfLoan { get; set; }

        public DateTime? DateOfReturn { get; set; }


        //Connect book and costumer trough loan

        public ICollection<Book> Books { get; set; } = new List<Book>(); 

        public Customer? Customer { get; set; } 
    }
}
   

