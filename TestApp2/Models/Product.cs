using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestApp2.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public virtual Category? Category { get; set; }
        public int Availability { get; set; }
        [DisplayName("URL")]
        public string ImageURL { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
