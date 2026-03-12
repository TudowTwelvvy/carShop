using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace carShop.ViewModels
{
    public class CarViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The car name cannot be blank")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter car name between 3 and 50 characters in length")]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "The car description cannot be blank")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Please enter a car description between 10 and 200 characters in length")]
        [RegularExpression(@"^[,;a-zA-Z0-9'-'\s]*$", ErrorMessage = "Please enter a car description made up of letters and numbers only")]
       [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "The price cannot be blank")]
   
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [RegularExpression("[0-9]+(\\.[0-9][0-9]?)?", ErrorMessage = "The price must be a number up to two decimal places")]
        public decimal Price { get; set; }
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public SelectList CategoryList { get; set; }
        public List<SelectList> ImageLists { get; set; }
        public string[] CarImages { get; set; }
    }
}