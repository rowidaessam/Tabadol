using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBProject.Models
{
    public class Order
    {
        [Required]
        public int OrderId { get; set; }
        public string Name { get; set; }
        public int Freight { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();


    }
}
