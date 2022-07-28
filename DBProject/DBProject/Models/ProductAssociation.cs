namespace DBProject.Models
{
    public class ProductAssociation
    {
        public int ProductID { get; set; }
        public int ASSId { get; set; }
        public Product Product { get; set; }
        public Association Association { get; set; }
    }
}
