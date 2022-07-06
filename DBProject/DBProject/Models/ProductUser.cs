namespace DBProject.Models
{
    public class ProductUser
    {
        public int UserId { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }

    }
}
