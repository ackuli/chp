using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HMS.Entities.Models;
using HMS.ViewModels;
using Repository.Pattern.UnitOfWork;
using HMS.Service.Models;
using MvcPaging;
namespace HMS.Controllers
{
    public class UserAccountsController : Controller
    {
        private HMSContext db = new HMSContext();
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAccountsService _iUserAccountsService;
        public UserAccountsController(IUnitOfWork unitOfWork, IUserAccountsService iUserAccountsService)
        {

            _iUserAccountsService = iUserAccountsService;
            _unitOfWork = unitOfWork;

        }

        public ActionResult Index(int? page, string searchItem)
        {

            const int defaultPageSize = 10;
            ViewData["searchItem"] = searchItem;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<UserAccount> lstUserAccount = _iUserAccountsService.GetAllUserAccount().OrderByDescending(x => x.RoleId).ToList();
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                lstUserAccount = lstUserAccount.ToPagedList(currentPageIndex, defaultPageSize);
            }
            else
            {
                lstUserAccount = lstUserAccount.Where(p => p.UserName.ToLower().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, defaultPageSize);
            }
            return View(lstUserAccount);

        }
       

        // GET: UserAccounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }
       
        // GET: UserAccounts/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: UserAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserAccountsId,Password,RoleId,UserDescription,SetDate,SetBy,EmailId,CountryId,PhoneNo")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.UserAccounts.Add(userAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", userAccount.CountryId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", userAccount.RoleId);
            return View(userAccount);
        }

        // GET: UserAccounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", userAccount.CountryId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", userAccount.RoleId);
            return View(userAccount);
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserAccountsId,Password,RoleId,UserDescription,SetDate,SetBy,EmailId,CountryId,PhoneNo")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", userAccount.CountryId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", userAccount.RoleId);
            return View(userAccount);
        }

        // GET: UserAccounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserAccount userAccount = db.UserAccounts.Find(id);
            db.UserAccounts.Remove(userAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
