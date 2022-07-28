
namespace DBProject.Models
{
    public class Card
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }
        
        [Required(ErrorMessage = "Enter Number of Products Please !! ")]
        public int NumberOfProducts { get; set; }

        [Required(ErrorMessage = "Enter Your Points Please !! ")]
        public int Points { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
