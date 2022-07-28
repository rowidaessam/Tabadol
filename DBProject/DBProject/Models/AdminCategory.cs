namespace DBProject.Models
{
    public class AdminCategory
    {
        public int CategoryID { get; set; }
        public int AdminId { get; set; }
        public Category Category { get; set; }
        public Admin Admin { get; set; }

    }
}
