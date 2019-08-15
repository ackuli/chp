using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.ViewModels;
using HMS.Models;

namespace HMS.Controllers
{
    public class cpController : Controller
    {
        //
        // GET: /cp/
        private HMSContext Context = new HMSContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult LoagIn(Login objLogin)
        {
            ActionResult rtnview = null;
            var UserAccounts = Context.UserAccounts.FirstOrDefault(x => x.Id == objLogin.UserID && x.Password == objLogin.Password);
            if (UserAccounts != null)
            {
                Session["UserId"] = UserAccounts.Id;
                rtnview = Redirect("Dashboard");
            }
            else
            {
                objLogin.Message = "Worng User Id or password";
                rtnview = View("Index", objLogin);
            }
            return rtnview;

        }


    }
}
