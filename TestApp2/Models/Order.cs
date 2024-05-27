using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10393673CLDVPOE.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public virtual Product? Product { get; set; }
        public int Quantity { get; set; }
        public string UserID { get; set; }
    }
}
