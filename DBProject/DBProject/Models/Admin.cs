using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBProject.Models
{
    public class Admin
    {
        [Required]
        public int AdminId { get; set; }

        //composite
        public string AdminName { get; set; }
        public int Password { get; set; }

        [ForeignKey("PersonalInformation")]
        public int SSN { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public virtual ICollection<AdminAssociation> AdminAssociations { get; set; } = new HashSet<AdminAssociation>();
        public virtual ICollection<AdminCategory> AdminCategories { get; set; } = new HashSet<AdminCategory>();



    }
}
