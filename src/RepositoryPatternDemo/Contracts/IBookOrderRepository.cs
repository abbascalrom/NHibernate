using System;
using System.Collections.Generic;
using RepositoryPatternDemo.Models;

namespace RepositoryPatternDemo.Contracts
{
    public interface IBookOrderRepository : IDisposable
    {
        IEnumerable<BookOrder> GetBookOrders();
        BookOrder GetBookOrderById(int bookId);        
        void InsertBookOrder(BookOrder bookOrder);        
        void DeleteBookOrder(int bookId);
        void UpdateBookOrder(BookOrder bookOrder);
        void Save();        
    }
}