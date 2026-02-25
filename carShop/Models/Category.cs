using System.Collections.Generic;

namespace carShop.Models
{
    public class Category
    {
        public int ID { get; set; } //PRIMARY KEY-CODE
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}