using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.ViewModels;
using HMS.Models;
using Repository.Pattern.UnitOfWork;
using HMS.Service.Models;
using HMS.utility;

namespace HMS.Controllers
{
    public class cPanelController : Controller
    {
        //
        // GET: /cPanel/

        private HMSContext Context = new HMSContext();
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAccountsService _iUserAccountsService;
        public cPanelController(IUnitOfWork unitOfWork, IUserAccountsService iUserAccountsService)
        {

            _iUserAccountsService = iUserAccountsService;
            _unitOfWork = unitOfWork;

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoagIn(Login objLogin)
        {
            ActionResult rtnview = null;
            var hashPassword = HashSecurity.EncryptString(objLogin.Password);
            var UserAccounts = _iUserAccountsService.GetUserAccountByUserIdandPassword(objLogin.UserID, hashPassword);
            if (UserAccounts != null)
            {
                Session["UserId"] = UserAccounts.UserAccountsId;
                Session["UserName"] = UserAccounts.UserName;
                rtnview = Redirect("Dashboard");
            }
            else
            {
                objLogin.Message = "Worng User Id or password";
                rtnview = View("Index", objLogin);
            }
            return rtnview;

        }

        public ActionResult LogOut()
        {
                Session["UserId"] ="";
                Session["UserName"] ="";
                return View("Index");

        }

    }
}
