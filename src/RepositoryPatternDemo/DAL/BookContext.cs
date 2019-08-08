using System.Data.Entity;
using RepositoryPatternDemo.Models;

namespace RepositoryPatternDemo.DAL
{
    public class BookContext : DbContext
    {
        public BookContext()
            : base("name=DBConStr")
        {           
        }

        public DbSet<Book> Books { get; set; }
    }
}