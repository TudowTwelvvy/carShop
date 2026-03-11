using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace carShop.Models
{
    public class CarImage
    {
        public int ID { get; set; }

        [Display(Name = "file")]
        [StringLength(100)]
        [Index(IsUnique =true)]

        public string FileName { get; set; }
        public virtual ICollection<CarImageMapping> CarImageMappings { get; set; }
    }
}