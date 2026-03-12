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

        [Required(ErrorMessage = "Please enter the name of the product.")]
        [StringLength(50, MinimumLength = 3, 
            ErrorMessage = "Please enter a product name between 3 and 50 characters in length.")] 
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description of the product.")]
        [StringLength(200, MinimumLength = 10, 
            ErrorMessage = "Please enter a product description between 10 and 200 characters in length.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$",
            ErrorMessage = "Please enter a product name beginning with a capital letter and made up of letters and spaces.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the price of the product.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [RegularExpression("[0-9]+(\\.[0-9][0-9]?)?", 
            ErrorMessage = "The price must be a number up to two decimals")]
        public decimal Price { get; set; }
        public int? CategoryID { get; set; } //Represents the ID of the category that the product is assigned to: FOREIGN KEY-CODE
        public virtual Category Category { get; set; } 
        // Image Property
        public string ImagePath { get; set; }

        public virtual ICollection<CarImageMapping> CarImageMappings { get; set; }

    }
}