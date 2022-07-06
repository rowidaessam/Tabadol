using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBProject.Models
{
    public class Product
    {
        [Required]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Points { get; set; }
        public int QuantityPerUnit { get; set; }
        public string ProductDescription { get; set; }
        public int UnitsOnOrder { get; set; }

        [Required(ErrorMessage = "Please Choose Product Image")]
        [Display(Name = "Product Image")]
        [NotMapped]
        public IFormFile ProductPicture { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<ProductAssociation> ProductAssociations { get; set; } = new HashSet<ProductAssociation>();
        public virtual ICollection<ProductUser> ProductUsers { get; set; } = new HashSet<ProductUser>();


    }
}
