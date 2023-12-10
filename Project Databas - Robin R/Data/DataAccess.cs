using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            using (Context context = new Context())
            {

                // Created Authors to use
                Author author1 = new Author { Name = "George Orwell" };


                Author author2 = new Author { Name = "J.R.R. Tolkien" };


                Author author3 = new Author { Name = "Harper Lee" };


                Author author4 = new Author { Name = "J.K Rowling" };


                Author author5 = new Author { Name = "Khaled Hosseini" };





                // Created Costumer to use
                Customer customer1 = new Customer
                {
                    FirstName = "Lewis",
                    LastName = "Hamilton",
                    CardID = 886623,
                    CardPin = 7612

                };


                Customer customer2 = new Customer
                {
                    FirstName = "Robin",
                    LastName = "Racho",
                    CardID = 991018,
                    CardPin = 9910
                };


                Customer customer3 = new Customer
                {
                    FirstName = "Abdi",
                    LastName = "Farah",
                    CardID = 218491,
                    CardPin = 1824
                };


                //Created Books to use
                Book book1 = new Book();
                book1.BookTitle = "1984";
                book1.Isbn = 239182345;
                book1.Rating = 9;
                book1.ReleaseDate = DateTime.Now;
                book1.IsRented = false;


                Book book2 = new Book();
                book2.BookTitle = "The Lord of the Rings";
                book2.Isbn = 321429219;
                book2.Rating = 10;
                book2.ReleaseDate = DateTime.Now;
                book2.IsRented = false;


                Book book3 = new Book();
                book3.BookTitle = "To Kill A MockingBird";
                book3.Isbn = 512213851;
                book3.Rating = 7;
                book3.ReleaseDate = DateTime.Now;
                book3.IsRented = false;


                Book book4 = new Book();
                book4.BookTitle = "Harry Potter and the Philosoper's Stone";
                book4.Isbn = 231412352;
                book4.Rating = 10;
                book4.ReleaseDate = DateTime.Now;
                book4.IsRented = false;

                Book book5 = new Book();
                book5.BookTitle = "The Kite Runner";
                book5.Isbn = 521321312;
                book5.Rating = 8;
                book5.ReleaseDate = DateTime.Now;
                book5.IsRented = false;





                //Add authors, books and customer to context

                context.Authors.AddRange(author1, author2, author3, author4);
                context.Books.AddRange(book1, book2, book3, book4);
                context.Customers.AddRange(customer1, customer2, customer3);


                context.SaveChanges();


                //Add loan for the books

                Loan loan1 = new Loan { CustomerID = customer1.CustomerID, DateOfLoan = DateTime.Now, DateOfReturn = null };
                Loan loan2 = new Loan { CustomerID = customer2.CustomerID, DateOfLoan = DateTime.Now, DateOfReturn = null };
                Loan loan3 = new Loan { CustomerID = customer3.CustomerID, DateOfLoan = DateTime.Now, DateOfReturn = null };

              
                context.SaveChanges();
            }
        }


        public void AddCustomer(string firstName, string lastName)
        {
            using (var context = new Context())
            {
                var newCustomer = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                };

                context.Customers.Add(newCustomer);

                context.SaveChanges();


            }

        }
        public void AddBook(string bookTitle, DateTime? releaseDate, int rating, List<string> authorNames)
        {
            using (var context = new Context())
            {
                //Get existing authors or create new authors if they don't exist

                var authors = authorNames.Select(authorName =>
                {
                    var existingAuthor = context.Authors.FirstOrDefault(a => a.Name == authorName);
                    return existingAuthor ?? new Author { Name = authorName };
                }).ToList();

                var newBook = new Book
                {
                    BookTitle = bookTitle,
                    ReleaseDate = releaseDate,
                    Rating = rating,
                    Authors = authors
                };

                //Add the new book to the list
                foreach (var author in authors)
                {
                    author.Books.Add(newBook);
                }

                context.Books.Add(newBook);
                context.SaveChanges();
            }
        }



        public void AddAuthor(string name)
        {
            using (var context = new Context())
            {
                var newAuthor = new Author
                {
                    Name = name,

                };

                context.Authors.Add(newAuthor);

                context.SaveChanges();


            }
        }




        public void BorrowBook(int bookId, int customerId)
        {

            using (var context = new Context())
            {

                Book book = context.Books.Find(bookId);
                Customer customer = context.Customers.Find(customerId);

                if (book != null && customer != null)
                {
                    if (book.Loan == null || book.Loan.DateOfReturn != null)
                    {
                        var loanDetails = new Loan
                        {
                            BookID = book.BookID,
                            CustomerID = customer.CustomerID,
                            DateOfLoan = DateTime.Now,
                            DateOfReturn = null
                        };

                        book.Loan = loanDetails;
                        book.IsRented = true;

                        context.Loans.Add(loanDetails);

                        customer.Loans.Add(loanDetails);

                        context.SaveChanges();

                        Console.WriteLine($"'{book.BookTitle}' has been rented to {customer.FirstName} {customer.LastName}.");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, {book.BookTitle} is not available at the moment, please choose to rent another book.");
                    }
                }
                else
                {
                    Console.WriteLine("Please make sure the book and customer exist before attempting to loan.");
                }
            }
        }




        public void ReturnBook(int bookId)
        {
            using (Context context = new Context())
            {
                Book book = context.Books
                    .Include(b => b.Loan)
                    .FirstOrDefault(b => b.BookID == bookId);

                if (book != null && book.IsRented)
                {
                    book.IsRented = false;
                    book.Loan.DateOfReturn = DateTime.Now;

                    context.SaveChanges();

                    Console.WriteLine($"Thank you for this time. The book'{book.BookTitle}' has been returned.");
                }
                else
                {
                    Console.WriteLine("Invalid book or book is not currently rented.");
                }
            }
        }






        public void DeleteBorrower(int customerId)
        {
            Context context = new Context();

            
            var borrowDelete = context.Customers.Find(customerId);

            
            if (borrowDelete != null)
            {
                
                context.Customers.Remove(borrowDelete);
                context.SaveChanges();
                Console.WriteLine($"'{borrowDelete.FirstName} {borrowDelete.LastName}' Has been removed.");
            }
            else
            {

                Console.WriteLine("Alreday been removed or has not been added");
            }
        }
        public void DeleteAuthor(int authorID)
        {
            using (Context context = new Context())
            {
               
                Author author = context.Authors.Find(authorID);

                
                if (author != null)
                {


                    
                    context.Authors.Remove(author);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Invalid author.");
                }

            }
        }

        public void DeleteBook(int bookID)
        {
            using (Context context = new Context())
            {
                
                Book book = context.Books.Find(bookID);

                
                if (book != null)
                {


                    
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Invalid book.");
                }

            }
        }
    }
}
