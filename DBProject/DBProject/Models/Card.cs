using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBProject.Models
{
    public class Card
    {
        [Required]
        public int CardId { get; set; }
        public int NumberOfProducts { get; set; }
        public int Points { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
