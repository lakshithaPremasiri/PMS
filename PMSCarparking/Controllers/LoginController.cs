using PMSCarparking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMSCarparking.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(parking objUser)
        {
            if (ModelState.IsValid)
            {
                using (PMSEntities db = new PMSEntities())
                {
                    parking obj = db.parkings.Where(a => a.user_name.Equals(objUser.user_name) && a.password.Equals(objUser.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Parking_id"] = obj.parking_id.ToString();
                        Session["UserName"] = obj.user_name.ToString();
                        return RedirectToAction("Count", "Count");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["Parking_id"] != null)
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