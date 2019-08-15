using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Logout(string returnUrl)
        {
            HMS.Admin.MvcApplication.GolbalSession.gblSession = null;
            TempData.Add("success", "Successfully Logout to the system");
            return RedirectToAction("Login", "Account");
        }
    }
}