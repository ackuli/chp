using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using HMS.Admin.Models;
using HMS.Entities;
using HMS.Admin.Utility;
using HMS.Entities.Models;
using HMS.Service;
using HMS.Service.Models;
using Repository.Pattern.UnitOfWork;
using HMS.utility;
using HMS.Admin.Utility;
namespace HMS.Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //public AccountController()
        //    : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        //{
        //}

        //public AccountController(UserManager<ApplicationUser> userManager)
        //{
        //    UserManager = userManager;
        //}
        private readonly IUserAccountsService _userAccountsService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRightsssService _roleRightService;
        public AccountController(IUserAccountsService userAccountsService
            //, IRequsitionService requsitionService
                         , IRoleRightsssService roleRightService
                         , IUnitOfWork unitOfWork
                        )
        {
            _userAccountsService = userAccountsService;
            // _requsitionService = requsitionService;
            _roleRightService = roleRightService;
            _unitOfWork = unitOfWork;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public  ActionResult Login(HMS.Entities.ViewModels.LoginViewModels model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                var hashPassword = HashSecurity.EncryptString(model.Password);

                var UserAccounts = _userAccountsService.GetUserAccount(model.UserName, hashPassword);
             
                //if (!UserAccounts.IsTermConditionAgreed)
                //{
                //    UserAccounts.IsTermConditionAgreed = model.IsTermsCondition;
                //    _userAccountsService.Update(UserAccounts);
                //    _unitOfWork.SaveChanges();
                //}
                if (UserAccounts != null)
                {
                    bool passMatch = hashPassword.Equals(UserAccounts.Password);

                    if (passMatch) 
                    {
                       // var dycriptedPass = HashSecurity.DecryptString(hashPassword);
                        UserAccounts = _userAccountsService.GetUserAccountByUserIdandPassword(model.UserName, hashPassword);
                        SetSessionnew(UserAccounts);
                        TempData.Add("success", "User Login Successfully.");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData.Add("danger", "Invalid username or password.");
                        return RedirectToAction("Login", "Account");
                        
                        
                    }
                }
                else
                {
                    TempData.Add("danger", "Invalid username or password.");
                    return RedirectToAction("Login", "Account");                   
                    
                }
            }          
            return View(model);
        }

        public ActionResult Logout(string returnUrl)
        {
            HMS.Admin.MvcApplication.GolbalSession.gblSession = null;
            TempData.Add("success", "Successfully Logout to the system");
            return RedirectToAction("Login", "Account");
        }

          
        public void SetSessionnew(UserAccount user)
        {
            
            var roleRights = _roleRightService.GetRightsByRoleIdAndAreaId(user.RoleId, user.ClientId).Select(x => x.RightId);
            
            var inboxcnt = 0;
            var outboxcnt = 0;                  
            HMSSession hmsSession = new HMSSession();
            if (user != null)
            {
                hmsSession.UserId = user.UserAccountsId;
                hmsSession.Name = user.UserName;
                hmsSession.RoleId = user.RoleId.ToString();
                hmsSession.UserPkId = user.Id;

                //hmsSession.IsActive = user.IsActive;
                hmsSession.ClientId = user.ClientId;
                hmsSession.ClientName = user.Client.ClientName == null ? user.Client.ClientName = "" : user.Client.ClientName.ToString();
                hmsSession.inboxcnt = inboxcnt.ToString();
                hmsSession.outboxcnt = outboxcnt.ToString();
                hmsSession.UserRights = roleRights.ToList();
            }
            HMS.Admin.MvcApplication.GolbalSession.gblSession = hmsSession;

        }
        
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

       
       
        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}