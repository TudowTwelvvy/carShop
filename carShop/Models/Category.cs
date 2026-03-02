using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace carShop.Models
{
    public class Category
    {
        public int ID { get; set; } //PRIMARY KEY-CODE
        [Required(ErrorMessage = "The category name cannot be blank")]
        [StringLength(50, MinimumLength = 3, 
            ErrorMessage ="Please enter a category name between 3 and 50 characters in length")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", 
            ErrorMessage = "Please enter a category name beginning with a capuital letter and made up of letters and spaces")]
        [Display(Name = "Category Name")]   
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}