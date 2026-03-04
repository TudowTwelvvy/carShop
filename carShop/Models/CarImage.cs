using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace carShop.Models
{
    public class CarImage
    {
        public int ID { get; set; }

        [Display(Name = "file")]
        public string FileName { get; set; }
    }
}