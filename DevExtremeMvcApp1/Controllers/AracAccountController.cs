using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevExtremeMvcApp1.Models;

namespace DevExtremeMvcApp1.Controllers
{
    public class AracAccountController : Controller
    {

        private MainModel db = new MainModel();
        public ActionResult Index()
        {

            using (MainModel db = new MainModel())
            {
                return View(db.Arac.ToList());
            }

        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Arac arac)
        {
            if (ModelState.IsValid)
            {
                using (MainModel db = new MainModel())
                {
                    db.Arac.Add(arac);
                    db.SaveChanges();
                    ViewBag.Message = arac.Marka + " " + arac.Plaka + "succesfull registered. ";
                }
                ModelState.Clear();


            }
            return View();
        }
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Arac arac = db.Arac.Find(id);
            if (arac == null)
            {
                return HttpNotFound();
            }
            return View(arac);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Arac arac = db.Arac.Find(id);
                db.Arac.Remove(arac);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arac arac = db.Arac.Find(id);
            if (arac == null)
            {
                return HttpNotFound();
            }
            return View(arac);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aracToUpdate = db.Arac.Find(id);
            if (TryUpdateModel(aracToUpdate, "",
               new string[] { " Marka ", "Model", "MotorTipi", "Plaka", "RuhsatSahibiAdi ", "RuhsatSahibiSoyadi", "yil", "km", "TicariBinek", "YakitTürü", "SurusTipi", "Bakimservisi" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(aracToUpdate);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arac arac = db.Arac.Find(id);
            if (arac == null)
            {
                return HttpNotFound();
            }
            return View(arac);
        }



    }
}