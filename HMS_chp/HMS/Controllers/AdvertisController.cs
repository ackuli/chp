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
using System.IO;
using HMS.Entities.ViewModels;

namespace HMS.Controllers
{
    public class AdvertisController : Controller
    {
        private HMSContext db = new HMSContext();

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdvertissService _iIAdvertissService;

        public AdvertisController(IUnitOfWork unitOfWork, IAdvertissService iIAdvertissService)
        {
            _iIAdvertissService = iIAdvertissService;
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var advertis = _iIAdvertissService.GetAllAdvertis();//.Include(a => a.AdvertisePosition).Include(a => a.AdvertiseType).Include(a => a.ClientInfo);
            return View(advertis.ToList());
        }
        public ActionResult PositionWiseAdvertiseList(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var advertise = _iIAdvertissService.GetAdvertisByPositionsId(id).ToList();
            if (advertise == null)
            {
                advertise = new List<Advertis>();
                Advertis objadvertis = new Advertis();
                objadvertis.AdvertisePositionsId = id;
                advertise.Add(objadvertis);
                // return HttpNotFound();
            }
            return View(advertise);
        }
        // GET: Advertis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertis advertis = _iIAdvertissService.Find(id);
            if (advertis == null)
            {
                return HttpNotFound();
            }
            return View(advertis);
        }

        // GET: Advertis/Create

        public ActionResult Create(int id)
        {
            ViewBag.AdvertisePositionsId = new SelectList(db.AdvertisePositions, "AdvertisePositionsId", "Name");
            ViewBag.AdvertiseTypeId = new SelectList(db.AdvertiseTypes, "AdvertiseTypeId", "Name");
            ViewBag.ClientId = new SelectList(db.ClientInfoes, "ClientId", "ClientIdentityId");

            Advertis advertise = new Advertis();
            advertise.AdvertisePositionsId = id;
            advertise.StartDate = DateTime.Now;
            advertise.EndDate = DateTime.Now;
            return View(advertise);
        }
        public byte[] ConvertsToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        // POST: Advertis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "AdvertiseId,Name,AdvertiseTypeId,Extension,AdvertiseContent,AdvertisePositionsId,StartDate,EndDate,IsActive,ClientId,IsDefault,SetBy,SetDate,Img,LastUpdatedTime,PriorityLevel")] Advertis advertis, IEnumerable<HttpPostedFileBase> files, string AdvertiseContent1, string AdvertiseContent2, string AdvertiseContent3, string AdvertiseContent4, string AdvertiseContent5)
        {
            bool OperationType = false;
            if (ModelState.IsValid)
            {
                if (advertis.AdvertiseTypeId == 2)
                {
                    advertis.LastUpdatedTime = DateTime.Now;
                    advertis.SetBy = "1233";
                    advertis.SetDate = DateTime.Now;
                    _iIAdvertissService.Insert(advertis);
                    _unitOfWork.SaveChanges();
                    OperationType = true;
                }
                else
                {
                    OperationType = _iIAdvertissService.SaveAdvertiseBinaryobj(advertis, files, _unitOfWork);
                }
                if (OperationType)
                {
                    return RedirectToAction("PositionWiseAdvertiseList", new { id = advertis.AdvertisePositionsId });
                }
            }
            ViewBag.AdvertisePositionsId = new SelectList(db.AdvertisePositions, "AdvertisePositionsId", "Name", advertis.AdvertisePositionsId);
            ViewBag.AdvertiseTypeId = new SelectList(db.AdvertiseTypes, "AdvertiseTypeId", "Name", advertis.AdvertiseTypeId);
            ViewBag.ClientId = new SelectList(db.ClientInfoes, "ClientId", "ClientIdentityId", advertis.ClientId);
            return View(advertis);
        }

        // GET: Advertis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertis advertis = _iIAdvertissService.Find(id);
            if (advertis == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvertisePositionsId = new SelectList(db.AdvertisePositions, "AdvertisePositionsId", "Name", advertis.AdvertisePositionsId);
            ViewBag.AdvertiseTypeId = new SelectList(db.AdvertiseTypes, "AdvertiseTypeId", "Name", advertis.AdvertiseTypeId);
            ViewBag.ClientId = new SelectList(db.ClientInfoes, "ClientId", "ClientIdentityId", advertis.ClientId);
            return View(advertis);
        }

        // POST: Advertis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "AdvertiseId,Name,AdvertiseTypeId,Extension,AdvertiseContent,AdvertisePositionsId,StartDate,EndDate,IsActive,ClientId,IsDefault,SetBy,SetDate,Img,LastUpdatedTime,PriorityLevel")] Advertis advertis)
        {
            if (ModelState.IsValid)
            {
                _iIAdvertissService.Update(advertis);
                _unitOfWork.SaveChanges();
                return RedirectToAction("PositionWiseAdvertiseList", new { id = advertis.AdvertisePositionsId });
            }
            ViewBag.AdvertisePositionsId = new SelectList(db.AdvertisePositions, "AdvertisePositionsId", "Name", advertis.AdvertisePositionsId);
            ViewBag.AdvertiseTypeId = new SelectList(db.AdvertiseTypes, "AdvertiseTypeId", "Name", advertis.AdvertiseTypeId);
            ViewBag.ClientId = new SelectList(db.ClientInfoes, "ClientId", "ClientIdentityId", advertis.ClientId);
            return View(advertis);
        }

        // GET: Advertis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertis advertis = _iIAdvertissService.Find(id);
            if (advertis == null)
            {
                return HttpNotFound();
            }
            return View(advertis);
        }

        // POST: Advertis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertis advertis = _iIAdvertissService.Find(id);
            _iIAdvertissService.Delete(advertis);
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
