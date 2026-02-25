using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace carShop.Models
{
    public partial class Car
    {
        public int ID { get; set; }  //USED FOR PRIMARY KEY-CODE
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? CategoryID { get; set; } //Represents the ID of the category that the product is assigned to: FOREIGN KEY-CODE
        public virtual Category Category { get; set; }

    }
}