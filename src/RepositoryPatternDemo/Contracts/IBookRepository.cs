using System;
using System.Collections.Generic;
using RepositoryPatternDemo.Models;

namespace RepositoryPatternDemo.Contracts
{
    public interface IBookRepository : IDisposable
    {
        IEnumerable<Book> GetBooks();
        Book GetBookByID(int bookId);        
        void InsertBook(Book book);        
        void DeleteBook(int bookID);
        void UpdateBook(Book book);
        void Save();        
    }
}