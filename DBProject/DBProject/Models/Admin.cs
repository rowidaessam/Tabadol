
namespace DBProject.Models
{
    public class Admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AdminId { get; set; }

        //composite
        [StringLength(50, MinimumLength =3)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Max length Admin Name must be is 50 letter and the min is 3 letter")]
        public string AdminFName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Max length Admin Name must be is 50 letter and the min is 3 letter")]
        public string AdminLName { get; set; }


        [Required(ErrorMessage ="Enter Your Password Please !! ")]
        [RegularExpression("/(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8}/g",ErrorMessage = "Password must meet requirements")]
        public int Password { get; set; }


        [ForeignKey("PersonalInformation")]
        public int SSN { get; set; }
        public PersonalInformation PersonalInformation { get; set; }

        public virtual ICollection<AdminAssociation> AdminAssociations { get; set; } = new HashSet<AdminAssociation>();
        public virtual ICollection<AdminCategory> AdminCategories { get; set; } = new HashSet<AdminCategory>();



    }
}
