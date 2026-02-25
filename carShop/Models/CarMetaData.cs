using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace carShop.Models
{
    [MetadataType(typeof(CarMetaData))]
    public partial class Car
    {
    }
    public class CarMetaData
    {
        [Display(Name = "Car Name")]
        public string Name { get; set; }
       
    }
}