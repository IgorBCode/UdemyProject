using System.ComponentModel.DataAnnotations;

namespace Udemy.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)] // validation condition
        [Display(Name = "Category Name")] 
        public string Name { get; set; }
        [Display(Name = "Display Order")] 
        [Range(1, 100, ErrorMessage = "Entry out of bounds.")] // validation condition
        public int DisplayOrder { get; set; }
    }
}
