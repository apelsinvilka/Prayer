using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrayForPay.Models;

namespace PrayForPay.Controllers
{
    public class HomeController : Controller
    {
        PrayerDBEntities _db;

        public HomeController()
        {
            _db = new PrayerDBEntities();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PrayerFeed()
        {
            ViewBag.Message = "Your prayer feed.";

            var entities = new PrayerDBEntities();

            return View(entities.Prayer.ToList());

        }

        public ActionResult PrayerCreate()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PrayerCreate(FormCollection form)
        {
            var prayerToAdd = new Prayer();

            // Deserialize (Include white list!)
            TryUpdateModel(prayerToAdd, new string[] { "UserId", "PrayerText" }, form.ToValueProvider());

            // Validate
            //if (String.IsNullOrEmpty(prayerToAdd.UserId))
            //    ModelState.AddModelError("Title", "Title is required!");
            if (String.IsNullOrEmpty(prayerToAdd.PrayerText))
                ModelState.AddModelError("Payer", "Prayer text!");

            // If valid, save movie to database
            if (ModelState.IsValid)
            {
                _db.AddToPrayer(prayerToAdd);
                _db.SaveChanges();
                return RedirectToAction("PrayerFeed");
            }

            // Otherwise, reshow form
            return View(prayerToAdd);
        }

        public ActionResult PrayerEdit(int id)
        {
            // Get movie to update
            var prayerToUpdate = _db.Prayer.First(m => m.Id == id);

            ViewData.Model = prayerToUpdate;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PrayerEdit(FormCollection form)
        {
            // Get movie to update
            var id = Int32.Parse(form["id"]);
            var prayerToUpdate = _db.Prayer.First(m => m.Id === id);

            // Deserialize (Include white list!)
            TryUpdateModel(prayerToUpdate, new string[] { "UserId", "PrayerText" }, form.ToValueProvider());

            // Validate
            //if (String.IsNullOrEmpty(prayerToUpdate.Title))
            //    ModelState.AddModelError("Title", "Title is required!");
            if (String.IsNullOrEmpty(prayerToUpdate.PrayerText))
                ModelState.AddModelError("Payer", "Prayer text");

            // If valid, save movie to database
            if (ModelState.IsValid)
            {
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Otherwise, reshow form
            return View(prayerToUpdate);
        }
    }
}
