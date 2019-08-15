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

namespace HMS.Controllers
{
    public class AdvertisePositionsController : Controller
    {
        private HMSContext db = new HMSContext();
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdvertisePositionService _iAdvertisePositionService;
        public AdvertisePositionsController(IUnitOfWork unitOfWork, IAdvertisePositionService iAdvertisePositionService)
        {
            _iAdvertisePositionService = iAdvertisePositionService;
            _unitOfWork = unitOfWork;

        }
        // GET: AdvertisePositions
        public ActionResult Index()
        {
            var advertisePositions = _iAdvertisePositionService.GetAllAdvertisePosition();
            return View(advertisePositions.ToList());
        }

        // GET: AdvertisePositions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertisePosition advertisePosition = _iAdvertisePositionService.Find(id);
            if (advertisePosition == null)
            {
                return HttpNotFound();
            }
            return View(advertisePosition);
        }
        public ActionResult DetailsList(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertisePosition advertisePosition = _iAdvertisePositionService.GetAdvertisePositionById(id);
            if (advertisePosition == null)
            {
                return HttpNotFound();
            }
            return View(advertisePosition);
        }
        // GET: AdvertisePositions/Create
        public ActionResult Create()
        {
            ViewBag.CurrencyType = new SelectList(db.CurrencyTypes, "CurrencyTypeId", "CurrencyName");
            ViewBag.PageId = new SelectList(db.PageTypes, "Id", "Name");
            return View();
        }

        // POST: AdvertisePositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdvertisePositionsId,Name,TargetId,Description,PageId,Height,Width,Amount,CurrencyType,SetBy,SetDate,IsDefault,LastUpdatedTime")] AdvertisePosition advertisePosition)
        {
            if (ModelState.IsValid)
            {
                advertisePosition.SetBy = "Admin";
                advertisePosition.SetDate = DateTime.Now;
                advertisePosition.LastUpdatedTime = DateTime.Now;
                _iAdvertisePositionService.Insert(advertisePosition);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrencyType = new SelectList(db.CurrencyTypes, "CurrencyTypeId", "CurrencyName", advertisePosition.CurrencyType);
            ViewBag.PageId = new SelectList(db.PageTypes, "Id", "Name", advertisePosition.PageId);
            return View(advertisePosition);
        }

        // GET: AdvertisePositions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertisePosition advertisePosition = _iAdvertisePositionService.Find(id);
            if (advertisePosition == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrencyType = new SelectList(db.CurrencyTypes, "CurrencyTypeId", "CurrencyName", advertisePosition.CurrencyType);
            ViewBag.PageId = new SelectList(db.PageTypes, "Id", "Name", advertisePosition.PageId);
            return View(advertisePosition);
        }

        // POST: AdvertisePositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdvertisePositionsId,Name,TargetId,Description,PageId,Height,Width,Amount,CurrencyType,SetBy,SetDate,IsDefault,LastUpdatedTime")] AdvertisePosition advertisePosition)
        {
            if (ModelState.IsValid)
            {
                advertisePosition.SetBy = "Admin";
                advertisePosition.SetDate = DateTime.Now;
                advertisePosition.LastUpdatedTime = DateTime.Now;
                _iAdvertisePositionService.Update(advertisePosition);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrencyType = new SelectList(db.CurrencyTypes, "CurrencyTypeId", "CurrencyName", advertisePosition.CurrencyType);
            ViewBag.PageId = new SelectList(db.PageTypes, "Id", "Name", advertisePosition.PageId);
            return View(advertisePosition);
        }

        // GET: AdvertisePositions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertisePosition advertisePosition = _iAdvertisePositionService.Find(id);
            if (advertisePosition == null)
            {
                return HttpNotFound();
            }
            return View(advertisePosition);
        }

        // POST: AdvertisePositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdvertisePosition advertisePosition = _iAdvertisePositionService.Find(id);
            _iAdvertisePositionService.Delete(advertisePosition);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
