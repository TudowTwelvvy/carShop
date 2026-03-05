using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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
        public ActionResult Upload()
        {
            return View();
        }

        // POST: CarImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            //check the user has entered a file
            if (file != null)
            {
                //check ifthe file is valid
                if (ValidateFile(file)) {
                    try {
                        SaveFileToDisk(file);
                    } catch (Exception ex) {
                        ModelState.AddModelError("FileName", "An error occurred while saving the file: " + ex.Message);
                        
                    }
                }
                else
                {
                    ModelState.AddModelError("FileName", "Invalid file. Please upload a valid image file (jpg, jpeg, png, gif) under 2MB.");
                }
            }
            else
            {
                //if the user has not entered a file return an error message
                ModelState.AddModelError("FileName", "Please select a file to upload.");
            }
            if (ModelState.IsValid)
            {
                db.CarImages.Add(new CarImage { FileName = file.FileName });
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    SqlException innerException = ex.InnerException.InnerException as SqlException;
                    if (ex.InnerException != null && innerException.Number == 2601)
                    {
                        ModelState.AddModelError("FileName", "A file with the same name already exists. Please choose a different file name.");
                    }
                    else
                    {
                        ModelState.AddModelError("FileName", "An error occurred while saving the file information to the database: " + ex.Message);
                    }
                    return View();
                }
                return RedirectToAction("Index");
            }

                return View();
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
