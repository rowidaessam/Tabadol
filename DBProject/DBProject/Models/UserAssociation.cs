namespace DBProject.Models
{
    public class UserAssociation
    {
        public int ASSId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Association Association { get; set; }
    }
}
