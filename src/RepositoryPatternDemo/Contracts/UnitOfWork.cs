using RepositoryPatternDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RepositoryPatternDemo.Contracts
{
    public class UnitOfWork
    {
        private BookRepository _bookRepository;
        private BookOrderRepository _bookOrderRepository;
    

        public UnitOfWork()
        {

        }



    }
}
