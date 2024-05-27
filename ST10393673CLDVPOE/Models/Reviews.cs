using System.ComponentModel;
using ST10393673CLDVPOE.Models;

namespace ST10393673CLDVPOE.Models
{
    public class Reviews
    {
        public int ReviewID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
