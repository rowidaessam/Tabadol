using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBProject.Models
{
    public class Category
    {
        [Required]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Choose Category Image")]
        [Display(Name = "Category Image")]
        [NotMapped]
        public IFormFile CategoryPicture { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<AdminCategory> AdminCategories { get; set; } = new HashSet<AdminCategory>();


    }
}
