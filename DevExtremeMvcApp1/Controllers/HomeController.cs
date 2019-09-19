using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExtremeMvcApp1.Models;

namespace DevExtremeMvcApp1.Controllers
{
    public class HomeController : Controller
    {
        MainModel db = new MainModel();

        public ActionResult Index()
        {
            try
            {
                var usr = db.YetkiliServis.Single(u => u.ServisUsername == "123" && u.ServisUserPassword == "123");
                return View();
            }
            catch
            {
                YetkiliServis us = new YetkiliServis();
                us.ServisUserEmail = "servis@gmail.com";
                us.ServisUsername = "123";
                us.ServisUserPassword = "123";
                db.YetkiliServis.Add(us);
                db.SaveChanges();
                return View();
            }
        }
    }
}