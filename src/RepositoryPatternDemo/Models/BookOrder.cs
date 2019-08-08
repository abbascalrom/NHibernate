using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPatternDemo.Models
{
    public class BookOrder
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }

        [MaxLength(30)]
        public string City { get; set; }
        public int Quantity { get; set; }
        public System.DateTime OrderDate { get; set; }        
    }
}