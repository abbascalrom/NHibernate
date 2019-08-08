using RepositoryPatternDemo.Helpers;
using RepositoryPatternDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Books CRUD functions

            BookRepositoryHelper repository = new BookRepositoryHelper();

            var book = new Book
            {
                Title = "some book",
                publishYear = "2019",
                Authers = "someone",
                BasePrice = 10
            };


            repository.Insert(book);
            Console.WriteLine("Book Added: " + book.Title);

            book.BasePrice = 20;

            repository.Edit(book);
            Console.WriteLine("Book Updated: " + book.Title);

            repository.GetById(book.Id);

            Console.WriteLine("Book Title: " + book.Title + "\t" + "Book publishYear: " + book.publishYear + "\t" + "Book Authers: " + book.Authers + "\t" + "Book BasePrice: " + book.BasePrice);

            repository.Delete(book.Id);
            Console.WriteLine("Book Deleted: " + book.Title);


            // Book ORder functions

            BookOrderRepositoryHelper boRepository = new BookOrderRepositoryHelper();

            var BookOrder = new BookOrder
            {
                BookId = 1,
                Quantity = 10,
                City = "Lahore",
                OrderDate = DateTime.Today
            };


            boRepository.Insert(BookOrder);
            Console.WriteLine("BookOrder Added: " + BookOrder.Quantity);

            BookOrder.Quantity = 20;

            boRepository.Edit(BookOrder);
            Console.WriteLine("BookOrder Updated: " + BookOrder.Quantity);

            boRepository.GetById(BookOrder.Id);

            Console.WriteLine("BookOrder Quantity: " + BookOrder.Quantity + "\t" + "BookOrder publishYear: " + BookOrder.City + "\t" + "BookOrder Authers: " + BookOrder.OrderDate);

            boRepository.Delete(BookOrder.Id);
            Console.WriteLine("BookOrder Deleted: " + BookOrder.Quantity);

            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Repository Pattern Demo Completed.");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.ReadKey();                      
        }
    }
}
