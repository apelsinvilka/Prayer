using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrayForPay.Models;
using System.Web.Security;
using System.Drawing;
using System.IO;

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
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

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

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PrayerCreate(FormCollection form)
        {
            var prayerToAdd = new Prayer();

            MembershipUser user = Membership.GetUser(User.Identity.Name);
            if (user == null)
            {
                throw new InvalidOperationException("User [" +
                    User.Identity.Name + " ] not found.");
            }

            // Do whatever u want with the unique identifier.
            Guid guid = (Guid)user.ProviderUserKey;

            // Deserialize (Include white list!)
            TryUpdateModel(prayerToAdd, new string[] { "UserId", "PrayerText" }, form.ToValueProvider());

            prayerToAdd.UserId = guid;

            prayerToAdd.Id = Guid.NewGuid();

            // Validate
            //if (String.IsNullOrEmpty(prayerToAdd.UserId))
            //    ModelState.AddModelError("UserId", "UserId is required!");
            if (String.IsNullOrEmpty(prayerToAdd.PrayerText))
                ModelState.AddModelError("Payer", "Prayer text!");

            
            //Start Create PIC

                string path = AppDomain.CurrentDomain.BaseDirectory + "image";
                string picPath = System.IO.Path.Combine(path, "img_empty.jpg");
                Image pic = Image.FromFile(picPath);
                pic = resizeImage(pic, new Size(700, 700));

                string picPathFilter = System.IO.Path.Combine(path, "Filter_Frame.png");
                Image picFilter = Image.FromFile(picPathFilter);
                picFilter = resizeImage(picFilter, new Size(700, 700));

                string picPathNew = System.IO.Path.Combine(path, form["imageId"]);
                Image picNew = Image.FromFile(picPathNew);
                picNew = resizeImage(picNew, new Size(700, 700));

                using (Graphics g = Graphics.FromImage(pic))
                {
                    Font drawFont = new Font("PT Serif", 24);
                    SolidBrush drawBrush = new SolidBrush(Color.White);
                    g.DrawImage(picNew, new Point(0, 0));
                    g.DrawImage(picFilter, new Point(0, 0));

                    //Start create text

                    // Create string to draw.
                    String drawString = prayerToAdd.PrayerText;

                    // Create rectangle for drawing.
                    float x = 0.0F;
                    float y = 250.0F;
                    float width = 700.0F;
                    float height = 700.0F;
                    RectangleF drawRect = new RectangleF(x, y, width, height);

                    // Draw rectangle to screen.
                    Pen blackPen = new Pen(Color.Empty);
                    g.DrawRectangle(blackPen, x, y, width, height);

                    // Set format of string.
                    StringFormat drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;

                    // Draw string to screen.
                    g.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);

                    //End create text
                }

                string picPathFinal = System.IO.Path.Combine(path, "ImageF.jpg");
                pic.Save(picPathFinal, System.Drawing.Imaging.ImageFormat.Jpeg);
                MemoryStream ms = new MemoryStream();
                pic.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            //END Create PIC

            // Save picture to database
                prayerToAdd.PrayerResult = ms.ToArray();
               

            // If valid, save movie to database
            //if (ModelState.IsValid)
            //{
            _db.AddToPrayer(prayerToAdd);
            _db.SaveChanges();

                return RedirectToAction("PrayerCreate");
            //}

            //// Otherwise, reshow form
            //return View(prayerToAdd);
        }

        public ActionResult PrayerEdit(int id)
        {
            //// Get movie to update
            //var prayerToUpdate = _db.Prayer.First(m => m.Id == id);

            //ViewData.Model = prayerToUpdate;
            return View();
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult PrayerEdit(FormCollection form)
        //{
        //    // Get movie to update
        //    var id = Int32.Parse(form["id"]);
        //    var prayerToUpdate = _db.Prayer.First(m => m.Id === id);

        //    // Deserialize (Include white list!)
        //    TryUpdateModel(prayerToUpdate, new string[] { "UserId", "PrayerText" }, form.ToValueProvider());

        //    // Validate
        //    //if (String.IsNullOrEmpty(prayerToUpdate.Title))
        //    //    ModelState.AddModelError("Title", "Title is required!");
        //    if (String.IsNullOrEmpty(prayerToUpdate.PrayerText))
        //        ModelState.AddModelError("Payer", "Prayer text");

        //    // If valid, save movie to database
        //    if (ModelState.IsValid)
        //    {
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    // Otherwise, reshow form
        //    return View(prayerToUpdate);
        //}


    }
}
