
namespace DBProject.Models
{
    public class OrderDetail
    {
        [Required(ErrorMessage = "Enter the Product ID Please !! ")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Enter Your POints Please !! ")]
        public int Points { get; set; }

        [Required(ErrorMessage = "Enter the Quantity !! ")]
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
