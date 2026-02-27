using carShop.DAL;
using carShop.Models;
using carShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace carShop.Controllers
{
    public class CarsController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Cars
        public ActionResult Index(string category, string search)
        {
            CarIndexViewModel viewModel = new CarIndexViewModel();

            var cars = db.Cars.Include(c => c.Category);

            //filter by category
            if(!String.IsNullOrEmpty(category))
            {
                cars = cars.Where(c => c.Category.Name == category);
            }

            //search cars by name or description
            if(!String.IsNullOrEmpty(search))
            {
                cars = cars.Where(c => c.Name.Contains(search) || 
                c.Description.Contains(search) || 
                c.Category.Name.Contains(search));
                viewModel.Search = search;
            }
            //group search results into categories and count how many items in each category
            viewModel.CatsWithCount = from matchingCars in cars
                                       where
                                       matchingCars.CategoryID != null
                                       group matchingCars by matchingCars.Category.Name into catGroup
                                        select new CategoryWithCount
                                        {
                                             CategoryName = catGroup.Key,
                                             CarCount = catGroup.Count()
                                        };

            if (!String.IsNullOrEmpty(category))
            {
                cars = cars.Where(c => c.Category.Name == category);
            }

            //var categories = cars.OrderBy(c => c.Category.Name).Select(c => c.Category.Name).Distinct();
            //ViewBag.Category = new SelectList(categories);
            viewModel.Cars = cars;

            return View(viewModel);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Price,CategoryID")] Car car, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                //image
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    ImageFile.SaveAs(path);
                    car.ImagePath = fileName;
                }

                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", car.CategoryID);
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", car.CategoryID);
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price,CategoryID")] Car car, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                var carInDb = db.Cars.Find(car.ID);

                if (carInDb == null)
                    return HttpNotFound();

                //image
                carInDb.Name = car.Name;
                carInDb.Description = car.Description;
                carInDb.Price = car.Price;
                carInDb.CategoryID = car.CategoryID;
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    // Delete old image
                    if (!string.IsNullOrEmpty(carInDb.ImagePath))
                    {
                        string oldPath = Path.Combine(Server.MapPath("~/Images/"), carInDb.ImagePath);
                        if (System.IO.File.Exists(oldPath))
                            System.IO.File.Delete(oldPath);
                    }

                    // Save new image
                    string fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    ImageFile.SaveAs(path);
                    carInDb.ImagePath = fileName;
                }
                //db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", car.CategoryID);
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            //image
            if (!string.IsNullOrEmpty(car.ImagePath))
            {
                string path = Path.Combine(Server.MapPath("~/Images/"), car.ImagePath);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
