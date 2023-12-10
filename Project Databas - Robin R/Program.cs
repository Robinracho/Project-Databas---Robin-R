using Project_Databas___Robin_R.Data;
using Project_Databas___Robin_R.Models;

namespace Project_Databas___Robin_R

{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            
            

            dataAccess.Seed();


            ////Create a new customer
            //dataAccess.AddCustomer("Robin", "Racho");
            //Console.WriteLine("Customer has been added.");


            ////Create an Author
            //dataAccess.AddAuthor("William Shakespear");
            //Console.WriteLine("Author has been added.");


            ////Create a new book
            //List<string> authorNames = new List<string> { "Tom Clancy" };
            //dataAccess.AddBook("Jack Ryan", new DateTime(2023, 12, 10), 8, authorNames);
            //Console.WriteLine("Book has been added.");


            ////Borrowed a book
            //dataAccess.BorrowBook(1, 1);


            ////Return a book
            //int bookIdToReturn = 1;
            //int customerIdReturning = 1;
            //dataAccess.ReturnBook(bookIdToReturn);

            ////Delete customer
            //int borrowerIdToDelete = 3;
            //dataAccess.DeleteBorrower(borrowerIdToDelete);

            ////Delete Book
            //int authorIdToDelete = 1;
            //dataAccess.DeleteAuthor(authorIdToDelete);
            //Console.WriteLine("Author has been deleted");

            ////Delete Author
            //int bookIdToDelete = 3;
            //dataAccess.DeleteBook(bookIdToDelete);
            //Console.WriteLine("Book has been deleted.");

        }
    }
}