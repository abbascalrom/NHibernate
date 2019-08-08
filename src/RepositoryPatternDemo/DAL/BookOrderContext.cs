using System.Data.Entity;
using RepositoryPatternDemo.Models;

namespace RepositoryPatternDemo.DAL
{
    public class BookOrderContext : DbContext
    {
        public BookOrderContext()
            : base("name=DBConStr")
        {           
        }

        public DbSet<BookOrder> BookOrders { get; set; }
    }
}