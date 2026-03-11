using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carShop.Models
{
    public class CarImageMapping
    {
        public int ID { get; set; }
        public int ImageNumber { get; set; }
        public int CarID { get; set; }
        public int CarImageID { get; set; }
        public virtual Car Car { get; set; }
        public virtual CarImage CarImage { get; set; }
    }
}