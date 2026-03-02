namespace carShop.Migrations
{
    using carShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<carShop.DAL.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(carShop.DAL.ShopContext context)
        {
            // ============================
            // CATEGORIES
            // ============================
            var categories = new List<Category>
            {
                new Category { Name = "Sedan" },
                new Category { Name = "SUV" },
                new Category { Name = "Hatchback" },
                new Category { Name = "Sports" },
                new Category { Name = "Luxury" },
                new Category { Name = "Bakkie" }
             };

            categories.ForEach(c => context.Categories.AddOrUpdate(x => x.Name, c));
            context.SaveChanges();


            // ============================
            // CARS (NO IMAGE)
            // ============================
            var cars = new List<Car>
            {
              new Car { Name="Toyota Corolla", Description="Reliable everyday sedan", Price=280000, CategoryID = context.Categories.First(c=>c.Name=="Sedan").ID },
              new Car { Name="Honda Civic", Description="Fuel efficient sedan", Price=300000, CategoryID = context.Categories.First(c=>c.Name=="Sedan").ID },
              new Car { Name="BMW 3 Series", Description="Sporty luxury sedan", Price=550000, CategoryID = context.Categories.First(c=>c.Name=="Sedan").ID },

              new Car { Name="Toyota Fortuner", Description="Powerful family SUV", Price=650000, CategoryID = context.Categories.First(c=>c.Name=="SUV").ID },
              new Car { Name="Ford Everest", Description="Premium SUV", Price=700000, CategoryID = context.Categories.First(c=>c.Name=="SUV").ID },
              new Car { Name="Hyundai Tucson", Description="Compact SUV", Price=480000, CategoryID = context.Categories.First(c=>c.Name=="SUV").ID },

              new Car { Name="VW Polo", Description="Popular hatchback", Price=260000, CategoryID = context.Categories.First(c=>c.Name=="Hatchback").ID },
              new Car { Name="Toyota Yaris", Description="City hatchback", Price=240000, CategoryID = context.Categories.First(c=>c.Name=="Hatchback").ID },
              new Car { Name="Ford Fiesta", Description="Stylish hatchback", Price=230000, CategoryID = context.Categories.First(c=>c.Name=="Hatchback").ID },

              new Car { Name="Mustang GT", Description="American muscle", Price=950000, CategoryID = context.Categories.First(c=>c.Name=="Sports").ID },
              new Car { Name="Porsche 911", Description="Iconic sports car", Price=2200000, CategoryID = context.Categories.First(c=>c.Name=="Sports").ID },
              new Car { Name="Audi R8", Description="High performance sports", Price=2500000, CategoryID = context.Categories.First(c=>c.Name=="Sports").ID },

              new Car { Name="Mercedes S-Class", Description="Ultimate luxury", Price=1800000, CategoryID = context.Categories.First(c=>c.Name=="Luxury").ID },
              new Car { Name="BMW 7 Series", Description="Executive comfort", Price=1700000, CategoryID = context.Categories.First(c=>c.Name=="Luxury").ID },
              new Car { Name="Audi A8", Description="Luxury flagship", Price=1650000, CategoryID = context.Categories.First(c=>c.Name=="Luxury").ID },

              new Car { Name="Toyota Hilux", Description="Reliable workhorse", Price=550000, CategoryID = context.Categories.First(c=>c.Name=="Bakkie").ID },
              new Car { Name="Ford Ranger", Description="Tough bakkie", Price=600000, CategoryID = context.Categories.First(c=>c.Name=="Bakkie").ID }
            };

            cars.ForEach(c => context.Cars.AddOrUpdate(x => x.Name, c));
            context.SaveChanges();
        }
    }
}
