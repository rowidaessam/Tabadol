
namespace DBProject.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter The Number Of Exchange Please !! ")]
        public int NumberOfExchanges { get; set; }

        [Required(ErrorMessage = "Enter Your Points Please !! ")]
        public int Points { get; set; }

        [Required(ErrorMessage = "Please Choose User Image")]
        [Display(Name = "Profile Picture")]
        [NotMapped]
        public IFormFile ProfilePicture { get; set; }

        [ForeignKey("PersonalInformation")]
        public int SSN { get; set; }
        public PersonalInformation PersonalInformation { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<ProductUser> ProductUsers { get; set; } = new HashSet<ProductUser>();
        public virtual ICollection<UserAssociation> UserAssociations { get; set; } = new HashSet<UserAssociation>();


    }
}
