
namespace DBProject.Models
{
    public class Association
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int ASSId { get; set; }

        [Required (ErrorMessage = "Max length Association Name must be is 30 letter and the min is 20 letter")]
        [StringLength(30, MinimumLength = 20)]
        [Display(Name = "Association Name")]
        public string ASSName { get; set; }

        //composite
        [Required(ErrorMessage = "Enter Your City Please !! ")]
        [StringLength(100)]
        [Display (Name ="City")]
        public string AssCity { get; set; }

        [Required(ErrorMessage = "Enter Your City Please !! ")]
        [StringLength(100)]
        [Display(Name = "Country")]
        public string AssCountry { get; set; }

        [Required(ErrorMessage = "Enter Your City Please !! ")]
        [StringLength(100)]
        [Display(Name = "Street")]
        public string AssStreet { get; set; }


        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public string Phone { get; set; }

        public virtual ICollection<AdminAssociation> AdminAssociations { get; set; } = new HashSet<AdminAssociation>();
        public virtual ICollection<ProductAssociation> ProductAssociations { get; set; } = new HashSet<ProductAssociation>();
        public virtual ICollection<UserAssociation> UserAssociations { get; set; } = new HashSet<UserAssociation>();



    }
}
