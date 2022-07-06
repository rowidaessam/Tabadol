using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBProject.Models
{
    public class PersonalInformation
    {
        [Required]
        [Key]
        public int SSN { get; set; }

        //composite 
        public string Name { get; set; }
        //composite
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Choose User Image")]
        [Display(Name = "User Image")]
        [NotMapped]
        public IFormFile Picture { get; set; }
        public string PostalCode { get; set; }



    }
}
