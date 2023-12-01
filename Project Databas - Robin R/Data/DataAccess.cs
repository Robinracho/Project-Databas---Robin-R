using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_Databas___Robin_R.Models;


namespace Project_Databas___Robin_R.Data
{
    internal class DataAccess
    {
        public void Seed()
        {
            Context context = new Context();

            Book book1 = new Book();
            book1.Title = "1984";
            book1.Author = "George Orwell";
            book1.Isbn = 239182345;
            book1.ReleaseDate = 1984 - 11 - 25;
            book1.Rating = 9;
            book1.IsRented = false;
            book1.DateOfLoan = null;
            book1.DateOfReturn = null;
         

            Book book2 = new Book();
            book2.Title = "The Lord of the Rings";
            book2.Author = "J.R.R. Tolkien";
            book2.Isbn = 321429219;
            book2.ReleaseDate = 2002 - 12 - 11;
            book2.Rating = 10;
            book2.IsRented = true;
            book2.DateOfLoan = 2023 - 12 - 30;
            book2.DateOfReturn = 2024 - 01 - 30;

            Book book3 = new Book();
            book3.Title = "The Kite Runner";
            book3.Author = "Khaled Hosseini";
            book3.Isbn = 521321312;
            book3.ReleaseDate = 2006 - 09 - 11;
            book3.Rating = 8;
            book3.IsRented = false;
            book3.DateOfLoan = null;
            book3.DateOfReturn = null;
           
           

            Book book4 = new Book();
            book4.Title = "Harry Potter and the Philosoper's Stone";
            book4.Author = "J.K";
            book4.Isbn = 231412352;
            book4.ReleaseDate = 1981 - 02 - 05;
            book4.Rating = 10;
            book4.IsRented = true;
            book1.DateOfLoan = 2006 - 10 - 15;
            book1.DateOfReturn = 2006 - 11 - 15;

            Book book5 = new Book();
            book5.Title = "To Kill A MockingBird";
            book5.Author = "Harper Lee";
            book5.Isbn = 512213851;
            book5.ReleaseDate = 2012 - 10 - 18;
            book5.Rating = 8;
            book5.IsRented = true;
            book1.DateOfLoan = 2022 - 09 - 30;
            book1.DateOfReturn = 2022 - 10 - 30;

            Library library1 = new Library();
            library1.Name = "Robins Library";


        }
    }
}
