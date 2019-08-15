using HMS.Entities.Models;
using HMS.Service.Models;
using HMS.Admin.Utility;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using System.IO;
using HMS.Entities.ViewModels;
using HMS.utility;
namespace HMS.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAccountsService _IUserService;
        private readonly IRolesService _roleService;
        private readonly IClientService _IClientService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBinaryObjectService _iBinaryObjectService;
        public UserController(
            IUserAccountsService IUserService, 
            IRolesService roleService,
            IClientService IClientService, 
            IUnitOfWork unitOfWork, 
            IBinaryObjectService iBinaryObjectService)
        {
            _IUserService = IUserService;
            _roleService = roleService;
            _IClientService = IClientService;
            _iBinaryObjectService = iBinaryObjectService;
            _unitOfWork = unitOfWork;

        }
        public ActionResult Index(VmUser up)
        {
            up = (up != null) ? up : new VmUser();

            var ClientId = HMS.Admin.MvcApplication.GolbalSession.gblSession.ClientId;
            var ClientName = HMS.Admin.MvcApplication.GolbalSession.gblSession.ClientName;
            var roleid = HMS.Admin.MvcApplication.GolbalSession.gblSession.RoleId;

            up.clientList = new List<KeyValuePair<int, string>>();
            if (roleid == "1")//Admin
            {
              up.clientList = _IClientService.GetKVP();
            }
            else if (roleid == "3")//Client
            {
              up.clientList.Add(new KeyValuePair<int, string>(ClientId, ClientName));
            }
            up.clientId = up.clientId > 0 ? up.clientId : 0;

            up.searchData = new List<UserAccount>();

            if (up.clientId > 0)
            {
                up.searchData = _IUserService.GetAllUserByClient(up.clientId).ToList();
            }

            return View(up);
        }

        [CustomActionFilterAttribute]
        public ActionResult UserCreate()
        {
            UserAccount usAcc = new UserAccount();
            var ClientId = HMS.Admin.MvcApplication.GolbalSession.gblSession.ClientId;
            var ClientName = HMS.Admin.MvcApplication.GolbalSession.gblSession.ClientName;
            var roleid = HMS.Admin.MvcApplication.GolbalSession.gblSession.RoleId;

            usAcc.clientList = new List<KeyValuePair<int, string>>();
            usAcc.roleList = new List<KeyValuePair<int, string>>();

            if (roleid == "1")//Admin
            {
                usAcc.clientList = _IClientService.GetKVP();
            }
            else if (roleid == "3")//Client
            {
                usAcc.clientList.Add(new KeyValuePair<int, string>(ClientId, ClientName));
                usAcc.ClientId = ClientId;
            }
            usAcc.roleList = _roleService.GetKVP();

            return View(usAcc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserCreate(UserAccount usAcc)
        {
            usAcc.SetDate = DateTime.Now;
            usAcc.Password = HashSecurity.EncryptString(usAcc.Password);
            usAcc.SetBy = HMS.Admin.MvcApplication.GolbalSession.gblSession.UserId;
            try
            {
                var result = _IUserService.GetAllUserAccount().ToList().Where(x => x.UserAccountsId.ToLower()==usAcc.UserAccountsId.ToLower());
                if (result.Count()==0)
                {
                    _IUserService.Insert(usAcc);
                    _unitOfWork.SaveChanges();
                }

            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [CustomActionFilterAttribute]
        public ActionResult Edit(int id)
        {
            UserAccount usAcc = new UserAccount();
            usAcc = _IUserService.Find(id);
            usAcc.Password = HashSecurity.DecryptString(usAcc.Password);
            var ClientId = HMS.Admin.MvcApplication.GolbalSession.gblSession.ClientId;
            var ClientName = HMS.Admin.MvcApplication.GolbalSession.gblSession.ClientName;
            var roleid = HMS.Admin.MvcApplication.GolbalSession.gblSession.RoleId;

            usAcc.clientList = new List<KeyValuePair<int, string>>();
            usAcc.roleList = new List<KeyValuePair<int, string>>();

            if (roleid == "1")//Admin
            {
                usAcc.clientList = _IClientService.GetKVP();
            }
            else if (roleid == "3")//Client
            {
                usAcc.clientList.Add(new KeyValuePair<int, string>(ClientId, ClientName));
                usAcc.ClientId = ClientId;
            }
            usAcc.roleList = _roleService.GetKVP();
            return View(usAcc);
        }

        [HttpPost]
        [ValidateInput(false)]
        [CustomActionFilterAttribute]
        public ActionResult Edit(UserAccount usAcc)
        {
            usAcc.SetDate = DateTime.Now;
            usAcc.Password = HashSecurity.EncryptString(usAcc.Password);
            usAcc.SetBy = HMS.Admin.MvcApplication.GolbalSession.gblSession.UserId;
            try
            {
                var result = _IUserService.GetAllUserAccount().ToList().Where(x => x.UserAccountsId.ToLower() == usAcc.UserAccountsId.ToLower() && x.Id != usAcc.Id);
                if (result.Count() == 0)
                {
                    UserAccount usA = _IUserService.Find(usAcc.Id);
                    usA.Id = usAcc.Id;
                    usA.UserAccountsId = usAcc.UserAccountsId;
                    usA.Password = usAcc.Password;
                    usA.UserName = usAcc.UserName;
                    usA.UserDescription = usAcc.UserDescription;
                    usA.RoleId = usAcc.RoleId;
                    usA.ClientId = usAcc.ClientId;
                    usA.EmailId = usAcc.EmailId;
                    usA.CountryId = usAcc.CountryId;
                    usA.PhoneNo = usAcc.PhoneNo;
                    usA.SetBy = usAcc.SetBy;
                    usA.SetDate = usAcc.SetDate;
                    usA.IsTermConditionAgreed = usAcc.IsTermConditionAgreed;

                    _IUserService.Update(usA);
                    _unitOfWork.SaveChanges();
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _IUserService.Delete(id);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(VmUserPass usAcc)
        {
            try
            {
                var id = HMS.Admin.MvcApplication.GolbalSession.gblSession.UserPkId;
                UserAccount usAccDb = new UserAccount();
                usAccDb = _IUserService.Find(id);
                var ecryPass = HashSecurity.EncryptString(usAcc.user.Password);
                if (ecryPass == usAccDb.Password)
                {
                    if (usAcc.NewPassword == usAcc.ConfirmPassword)
                    {
                        usAccDb.Password = HashSecurity.EncryptString(usAcc.NewPassword);
                        usAccDb.SetDate = DateTime.Now;
                        usAccDb.SetBy = HMS.Admin.MvcApplication.GolbalSession.gblSession.UserId;
                        _IUserService.Update(usAccDb);
                        _unitOfWork.SaveChanges();
                        return RedirectToAction("Index","Home");
                    }
                }

            }
            catch
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
