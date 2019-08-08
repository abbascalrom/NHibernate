using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternDemo.Contracts;
using RepositoryPatternDemo.DAL;
using RepositoryPatternDemo.Models;

namespace RepositoryPatternDemo.Helpers
{
    public class BookRepositoryHelper
    {
        private readonly IBookRepository _bookRepository;

        public BookRepositoryHelper()
        {
            this._bookRepository = new DAL.BookRepository(new BookContext());
        }

        public IEnumerable<Book> GetAll()
        {
            var books = from book in _bookRepository.GetBooks()
                        select book;

            return books;
        }

        public Book GetById(int id)
        {
            var book = _bookRepository.GetBookByID(id);

            return book;
        }

        public bool Insert(Book book)
        {
            try
            {
                _bookRepository.InsertBook(book);
                _bookRepository.Save();
            }
            catch (DataException ex)
            {
                return false;
            }
            return true;
        }

        public bool Edit(Book book)
        {
            try
            {
                _bookRepository.UpdateBook(book);
                _bookRepository.Save();
            }
            catch (DataException ex)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                ////var book = _bookRepository.GetBookByID(id);
                _bookRepository.DeleteBook(id);
                _bookRepository.Save();
            }
            catch (DataException ex)
            {
                return false;
            }
            return true;
        }
    }
}
