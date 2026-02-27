using carShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace carShop.ViewModels
{
    public class CarIndexViewModel
    {
        public IQueryable<Car> Cars { get; set; }
        public string Search { get; set; }
        public IEnumerable<CategoryWithCount> CatsWithCount { get; set; }
        public string Category { get; set; }

        public IEnumerable<SelectListItem> CatFilterItems
        {
            get
            {
                var allCategories = CatsWithCount.Select(c => new SelectListItem
                {
                    Value= c.CategoryName,
                    Text = c.CatNameWithCount
                });
                return allCategories;
            }
        }
    }

    public class CategoryWithCount
    {
        public int CarCount { get; set; }
        public string CategoryName { get; set; }
        public string CatNameWithCount 
        {
            get
            {
                return CategoryName + " ("+ CarCount.ToString()+")";
            }
        }
    }
}