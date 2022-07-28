namespace DBProject.Models
{
    public class AdminAssociation
    {
        public int AdminId { get; set; }
        public int ASSId { get; set; }
        public Admin Admin { get; set; }
        public Association Association { get; set; }

    }
}
