using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HMS.Entities.Models;
using HMS.Service.Models;
using Repository.Pattern.UnitOfWork;

namespace HMS.Controllers
{
    public class EventsTypesController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventsTypesService _iEventsTypesService;
        // GET: EventsTypes
        public EventsTypesController(IUnitOfWork unitOfWork, IEventsTypesService iEventsTypesService)
        {

            _iEventsTypesService = iEventsTypesService;
            _unitOfWork = unitOfWork;

        }
        public ActionResult Index()
        {
            return View(_iEventsTypesService.GetAllEventsType().ToList());
        }

        // GET: EventsTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsType eventsType = _iEventsTypesService.Find(id);
            if (eventsType == null)
            {
                return HttpNotFound();
            }
            return View(eventsType);
        }

        // GET: EventsTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventsTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventsTypeId,EventsTypeName,IsActive")] EventsType eventsType)
        {
            if (ModelState.IsValid)
            {
                _iEventsTypesService.Insert(eventsType);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventsType);
        }

        // GET: EventsTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsType eventsType = _iEventsTypesService.Find(id);
            if (eventsType == null)
            {
                return HttpNotFound();
            }
            return View(eventsType);
        }

        // POST: EventsTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventsTypeId,EventsTypeName,IsActive")] EventsType eventsType)
        {
            if (ModelState.IsValid)
            {
                _iEventsTypesService.Update(eventsType);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventsType);
        }

        // GET: EventsTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsType eventsType = _iEventsTypesService.Find(id);
            if (eventsType == null)
            {
                return HttpNotFound();
            }
            return View(eventsType);
        }

        // POST: EventsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventsType eventsType = _iEventsTypesService.Find(id);
            _iEventsTypesService.Delete(eventsType);
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
