using carShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carShop.DAL
{
    public class CarsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            var categories = new List<Category>
            {
                new Category{ Name="Sport"},
                new Category{Name="SUV"},
                new Category{ Name="Sedan"},
                new Category{ Name="Hatchback"},
                new Category{ Name="Coupe"}
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();
           /* var cars = new List<Models.Car>
            {
                new Models.Car{Make="BMW", Model="M3", Year=2018, Price=60000, CategoryID=1},
                new Models.Car{Make="Audi", Model="Q5", Year=2019, Price=45000, CategoryID=2},
                new Models.Car{Make="Mercedes", Model="C-Class", Year=2020, Price=55000, CategoryID=3},
                new Models.Car{Make="Volkswagen", Model="Golf", Year=2017, Price=20000, CategoryID=4}
            };
            cars.ForEach(c => context.Cars.Add(c));
            context.SaveChanges();*/
        }
    }
}