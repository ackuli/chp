using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HMS.Entities.Models;
using Repository.Pattern.UnitOfWork;
using HMS.Service.Models;
using MvcPaging;
namespace HMS.Controllers
{
    public class ClientInfoesController : Controller
    {
        private HMSContext db = new HMSContext();
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientInfosService _iClientInfoService;
        public ClientInfoesController(IUnitOfWork unitOfWork, IClientInfosService iClientInfoService)
        {

            _iClientInfoService = iClientInfoService;
            _unitOfWork = unitOfWork;

        }

         public ActionResult Index(int? page, string searchItem)
        {

            const int defaultPageSize = 10;
            ViewData["searchItem"] = searchItem;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<ClientInfo> lstClientInfo = _iClientInfoService.GetAllClientInfo().OrderByDescending(x => x.ClientName).ToList();
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                lstClientInfo = lstClientInfo.ToPagedList(currentPageIndex, defaultPageSize);
            }
            else
            {
                lstClientInfo = lstClientInfo.Where(p => p.ClientName.ToLower().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, defaultPageSize);
            }
            return View(lstClientInfo);

        }
            

        // GET: ClientInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientInfo clientInfo = db.ClientInfoes.Find(id);
            if (clientInfo == null)
            {
                return HttpNotFound();
            }
            return View(clientInfo);
        }

        // GET: ClientInfoes/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewBag.CurrencyType = new SelectList(db.CurrencyTypes, "CurrencyTypeId", "CurrencyName");
            ViewBag.SetBy = new SelectList(db.UserAccounts, "UserAccountsId", "Password");
            return View();
        }

        // POST: ClientInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,ClientIdentityId,ClientName,Address,Amount,Setdate,LastUpdatedTime,SetBy,ContactNumber,EmailAddress,Img,CurrencyType,IsActive,CountryId")] ClientInfo clientInfo)
        {
            if (ModelState.IsValid)
            {
                db.ClientInfoes.Add(clientInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", clientInfo.CountryId);
            ViewBag.CurrencyType = new SelectList(db.CurrencyTypes, "CurrencyTypeId", "CurrencyName", clientInfo.CurrencyType);
            ViewBag.SetBy = new SelectList(db.UserAccounts, "UserAccountsId", "Password", clientInfo.SetBy);
            return View(clientInfo);
        }

        // GET: ClientInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientInfo clientInfo = db.ClientInfoes.Find(id);
            if (clientInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", clientInfo.CountryId);
            ViewBag.CurrencyType = new SelectList(db.CurrencyTypes, "CurrencyTypeId", "CurrencyName", clientInfo.CurrencyType);
            ViewBag.SetBy = new SelectList(db.UserAccounts, "UserAccountsId", "Password", clientInfo.SetBy);
            return View(clientInfo);
        }

        // POST: ClientInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,ClientIdentityId,ClientName,Address,Amount,Setdate,LastUpdatedTime,SetBy,ContactNumber,EmailAddress,Img,CurrencyType,IsActive,CountryId")] ClientInfo clientInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", clientInfo.CountryId);
            ViewBag.CurrencyType = new SelectList(db.CurrencyTypes, "CurrencyTypeId", "CurrencyName", clientInfo.CurrencyType);
            ViewBag.SetBy = new SelectList(db.UserAccounts, "UserAccountsId", "Password", clientInfo.SetBy);
            return View(clientInfo);
        }

        // GET: ClientInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientInfo clientInfo = db.ClientInfoes.Find(id);
            if (clientInfo == null)
            {
                return HttpNotFound();
            }
            return View(clientInfo);
        }

        // POST: ClientInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientInfo clientInfo = db.ClientInfoes.Find(id);
            db.ClientInfoes.Remove(clientInfo);
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
