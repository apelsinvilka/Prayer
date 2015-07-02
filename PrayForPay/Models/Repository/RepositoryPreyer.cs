using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace PrayForPay.Models.Repository
{
    public class RepositoryPreyer : IRepository
    {

        private void CreatePic()
        {
            Image pic = Image.FromFile("~/Content/images/img_1.jpg");

            Image picNew = null;

            using (Graphics g = Graphics.FromImage(pic))
            {
                Font drawFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                g.DrawString("test text", drawFont, drawBrush, new Point(50, 50));
                g.DrawImage(picNew, new Point(100, 100)); //логотип
            }
            pic.Save("Image.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

        }


    }
}
