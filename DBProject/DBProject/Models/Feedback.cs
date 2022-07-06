using System.ComponentModel.DataAnnotations.Schema;

namespace DBProject.Models
{
    public class Feedback
    {
        // one to many with user
        public string TookFeedback { get; set; }
        public string GaveFeedback { get; set; }
        public int ProductID { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
