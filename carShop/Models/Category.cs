using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace carShop.Models
{
    public class Category
    {
        public int ID { get; set; } //PRIMARY KEY-CODE
        [Display(Name = "Category Name")]   
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}