
namespace DBProject.Models
{
    public class Category
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        [StringLength(40, MinimumLength = 5)]
        [Required(ErrorMessage = "Max length Category Name must be is 40 letter and the min is 5 letter")]
        [Display(Name ="Category Name" )]
        public string CategoryName { get; set; }

        [StringLength(200, MinimumLength = 20)]
        [Required (ErrorMessage = "Max length Description must be is 200 letter and the min is 20 letter")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Choose Category Image")]
        [Display(Name = "Category Image")]
        [NotMapped]
        public IFormFile CategoryPicture { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<AdminCategory> AdminCategories { get; set; } = new HashSet<AdminCategory>();


    }
}
