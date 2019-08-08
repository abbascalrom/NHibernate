using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RepositoryPatternDemo.Contracts;
using RepositoryPatternDemo.Models;


namespace RepositoryPatternDemo.DAL
{
    public class BookOrderRepository : IBookOrderRepository
    {
        private readonly BookOrderContext _context;

        public BookOrderRepository(BookOrderContext bookOrderContext)
        {
            this._context = bookOrderContext;
        }

        public IEnumerable<BookOrder> GetBookOrders()
        {
            return _context.BookOrders.ToList();
        }

        public BookOrder GetBookOrderById(int bookId)
        {
            return _context.BookOrders.Find(bookId);
        }

        public void InsertBookOrder(BookOrder bookOrder)
        {
            _context.BookOrders.Add(bookOrder);
        }

        public void DeleteBookOrder(int bookId)
        {
            BookOrder bookOrder = _context.BookOrders.Find(bookId);
            _context.BookOrders.Remove(bookOrder);
        }

        public void UpdateBookOrder(BookOrder bookOrder)
        {
            _context.Entry(bookOrder).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
