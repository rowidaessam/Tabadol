
namespace DBProject.Models
{
    public class Feedback
    {
        // one to many with user
        [Required(ErrorMessage = "Enter the Took Feedback Please !! ")]
        [StringLength(300, MinimumLength = 30)]
        [Display(Name = "Took Feedback ")]
        public string TookFeedback { get; set; }

        [Required(ErrorMessage = "Enter the Gave Feedback Please !! ")]
        //[StringLength(300, MinimumLength = 30)]
        [Display(Name = " Gave Feedback ")]
        public string GaveFeedback { get; set; }

        [Required(ErrorMessage = "Enter the Product ID Please !! ")]
        public int ProductID { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
