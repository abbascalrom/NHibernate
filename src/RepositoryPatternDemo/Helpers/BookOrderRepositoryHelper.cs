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
    public class BookOrderRepositoryHelper
    {
        private readonly IBookOrderRepository _BookOrderRepository;

        public BookOrderRepositoryHelper()
        {
            this._BookOrderRepository = new DAL.BookOrderRepository(new BookOrderContext());
        }

        public IEnumerable<BookOrder> GetAll()
        {
            var bookOrders = from book in _BookOrderRepository.GetBookOrders()
                        select book;

            return bookOrders;
        }

        public BookOrder GetById(int id)
        {
            var bookOrder = _BookOrderRepository.GetBookOrderById(id);

            return bookOrder;
        }

        public bool Insert(BookOrder bookOrder)
        {
            try
            {
                _BookOrderRepository.InsertBookOrder(bookOrder);
                _BookOrderRepository.Save();
            }
            catch (DataException ex)
            {
                return false;
            }
            return true;
        }

        public bool Edit(BookOrder bookOrder)
        {
            try
            {
                _BookOrderRepository.UpdateBookOrder(bookOrder);
                _BookOrderRepository.Save();
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
                ////var book = _BookOrderRepository.GetBookByID(id);
                _BookOrderRepository.DeleteBookOrder(id);
                _BookOrderRepository.Save();
            }
            catch (DataException ex)
            {
                return false;
            }
            return true;
        }
    }
}
