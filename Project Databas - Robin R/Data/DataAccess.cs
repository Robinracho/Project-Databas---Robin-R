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
            book1.ReleaseDate = new DateTime( 1984, 11, 25);
            book1.Rating = 9;
            book1.IsRented = false;
            book1.DateOfLoan = null;
            book1.DateOfReturn = null;
         

            Book book2 = new Book();
            book2.Title = "The Lord of the Rings";
            book2.Author = "J.R.R. Tolkien";
            book2.Isbn = 321429219;
            book2.ReleaseDate = new DateTime(2002, 12, 11);
            book2.Rating = 10;
            book2.IsRented = true;
            book2.DateOfLoan = new DateTime(2023, 12, 30);
            book2.DateOfReturn = new DateTime(2024, 01, 30);

            Book book3 = new Book();
            book3.Title = "The Kite Runner";
            book3.Author = "Khaled Hosseini";
            book3.Isbn = 521321312;
            book3.ReleaseDate = new DateTime(2006, 09, 11);
            book3.Rating = 8;
            book3.IsRented = false;
            book3.DateOfLoan = null;
            book3.DateOfReturn = null;
           
           

            Book book4 = new Book();
            book4.Title = "Harry Potter and the Philosoper's Stone";
            book4.Author = "J.K";
            book4.Isbn = 231412352;
            book4.ReleaseDate = new DateTime(1981, 02, 05);
            book4.Rating = 10;
            book4.IsRented = true;
            book1.DateOfLoan = new DateTime(2006, 10, 15);
            book1.DateOfReturn = new DateTime(2006, 11, 15);

            Book book5 = new Book();
            book5.Title = "To Kill A MockingBird";
            book5.Author = "Harper Lee";
            book5.Isbn = 512213851;
            book5.ReleaseDate = new DateTime(2012, 10, 18);
            book5.Rating = 8;
            book5.IsRented = true;
            book1.DateOfLoan = new DateTime(2022, 09, 30);
            book1.DateOfReturn = new DateTime(2022, 10, 30);

         

            Customer customer1 = new Customer();
            customer1.FirstName = "Robin";
            customer1.LastName = "Racho";
            customer1.CardID = 991018;
            customer1.CardPin = 1999;

            Customer customer2 = new Customer();
            customer2.FirstName = "Abdi";
            customer2.LastName = "Farah";
            customer2.CardID = 218491;
            customer2.CardPin = 1824;

            Customer customer3 = new Customer();
            customer3.FirstName = "Lewis";
            customer3.LastName = "Hamilton";
            customer3.CardID = 886623;
            customer3.CardPin = 7612;

            context.Books.Add(book1);
            context.Books.Add(book2);
            context.Books.Add(book3);
            context.Books.Add(book4);
            context.Books.Add(book5);


            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);



            context.SaveChanges();
            Console.WriteLine("Completed");
        }

        public void BorrowBook(int bookId, int cardNumber)
        {
            using (Context context = new Context())
            {
                Book book = context.Books.Find(bookId);
                Customer customer = context.Customers.Find(cardNumber);

                if (book != null && customer != null && !book.IsRented)
                {
                    book.IsRented = true;
                    book.DateOfLoan = DateTime.Now;
                    book.DateOfReturn = null;

                    customer.BooksBorrowed.Add(book);

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Book not available for borrowing or invalid customer.");
                }
            }
        }

        public void ReturnBook(int bookId)
        {
            using (Context context = new Context())
            {
                Book book = context.Books.Find(bookId);

                if (book != null && book.IsRented)
                {
                    book.IsRented = false;
                    book.DateOfReturn = DateTime.Now;

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Invalid book or book is not currently rented.");
                }
            }
        }

        public void DisplayBorrowedBooks(int cardNumber)
        {
            using (Context context = new Context())
            {
                Customer customer = context.Customers.Include(c => c.BooksBorrowed).FirstOrDefault(c => c.CardID == cardNumber);

                if (customer != null)
                {
                    Console.WriteLine($"Books rented by {customer.FirstName} {customer.LastName}:");
                    foreach (var book in customer.BooksBorrowed)
                    {
                        Console.WriteLine($"{book.Title} by {book.Author}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid customer.");
                }
            }
        }

        public void DeleteBorrower(int cardNumber)
        {
            using (Context context = new Context())
            {
                Customer customer = context.Customers.Find(cardNumber);

                if (customer != null)
                {
                    foreach (var book in customer.BooksBorrowed.ToList())
                    {
                        context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    }

                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Invalid customer.");
                }

            }
        }
    }
}

        




       
            
        

    

