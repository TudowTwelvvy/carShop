using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using carShop.DAL;
using carShop.Models;

namespace carShop.Controllers
{
    public class CarImagesController : Controller
    {
        private ShopContext db = new ShopContext();



        // GET: CarImages
        public ActionResult Index()
        {
            return View(db.CarImages.ToList());
        }

        // GET: CarImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarImage carImage = db.CarImages.Find(id);
            if (carImage == null)
            {
                return HttpNotFound();
            }
            return View(carImage);
        }

        // GET: CarImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FileName")] CarImage carImage)
        {
            if (ModelState.IsValid)
            {
                db.CarImages.Add(carImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carImage);
        }

        // GET: CarImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarImage carImage = db.CarImages.Find(id);
            if (carImage == null)
            {
                return HttpNotFound();
            }
            return View(carImage);
        }

        // POST: CarImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FileName")] CarImage carImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carImage);
        }

        // GET: CarImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarImage carImage = db.CarImages.Find(id);
            if (carImage == null)
            {
                return HttpNotFound();
            }
            return View(carImage);
        }

        // POST: CarImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarImage carImage = db.CarImages.Find(id);
            db.CarImages.Remove(carImage);
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

        private bool ValidateFile(HttpPostedFileBase file)
        {
            string fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            if ((file.ContentLength > 0 && file.ContentLength < 2097152) && allowedExtensions.Contains(fileExtension))
            {
                return true;
            }

            return false;

        }
        private void SaveFileToDisk(HttpPostedFileBase file)
        {
            WebImage img = new WebImage(file.InputStream);
            if (img.Width > 190)
            {
                img.Resize(190, img.Height);
            }

            img.Save(Constants.CarImagePath + file.FileName);
            if (img.Width > 300)
            {
                img.Resize(300, img.Height);
            }

            img.Save(Constants.CarThumbnailPath + file.FileName);
        }
    }
}
