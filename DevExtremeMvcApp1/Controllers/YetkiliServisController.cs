using DevExtremeMvcApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevExtremeMvcApp1.Controllers
{
    public class YetkiliServisController : Controller
    {
        // GET: YetkiliServis
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(YetkiliServis yetkiliServis)
        {
            using (MainModel db = new MainModel())
            {
                var usr = db.YetkiliServis.Single(u => u.ServisUsername == yetkiliServis.ServisUsername && u.ServisUserPassword == yetkiliServis.ServisUserPassword);
                if (usr != null)
                {
                    Session["ServisUserID"] = usr.ServisUserID.ToString();
                    Session["ServisUsername"] = usr.ServisUsername.ToString();

                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
            return View();

        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}