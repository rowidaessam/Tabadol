
namespace DBProject.Models
{
    public class Product
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Enter Your Product Name Please !! ")]
        [StringLength(50)]
        [Display(Name = "Product Name ")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Enter Your Points Please !! ")]
        public int Points { get; set; }

        [Required(ErrorMessage = "Enter Your Quantity Please !! ")]
        [Display(Name = "Quantity Per Unit")]
        public int QuantityPerUnit { get; set; }

        [Required(ErrorMessage ="Enter Product Description please !! ")]
        [StringLength(200, MinimumLength = 20)]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Enter Units on Order please !! ")]
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
