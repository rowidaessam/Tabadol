using System.ComponentModel.DataAnnotations;

namespace DBProject.Models
{
    public class Association
    {
        [Required]
        [Key]
        public int ASSId { get; set; }
        public string ASSName { get; set; }
        //composite
        public string ASSAdress { get; set; }
        public string phone { get; set; }

        public virtual ICollection<AdminAssociation> AdminAssociations { get; set; } = new HashSet<AdminAssociation>();
        public virtual ICollection<ProductAssociation> ProductAssociations { get; set; } = new HashSet<ProductAssociation>();
        public virtual ICollection<UserAssociation> UserAssociations { get; set; } = new HashSet<UserAssociation>();



    }
}
