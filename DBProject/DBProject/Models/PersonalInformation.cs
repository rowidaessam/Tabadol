
namespace DBProject.Models
{
    public class PersonalInformation
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SSN { get; set; }

        //composite 

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Max length User Name must be is 50 letter and the min is 3 letter")]
        public string FName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Max length User Name must be is 50 letter and the min is 3 letter")]
        public string LName { get; set; }

        //composite

        [Required(ErrorMessage = "Enter Your City Please !! ")]
        [StringLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter Your Country Please !! ")]
        [StringLength(100)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Enter Your Street Please !! ")]
        [StringLength(100)]
        public string Street { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Your Phone Number Please !! ")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid Number ! ")]
        public string Phone { get; set; }

        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please Choose User Image")]
        [Display(Name = "User Image")]
        [NotMapped]
        public IFormFile Picture { get; set; }


        



    }
}
