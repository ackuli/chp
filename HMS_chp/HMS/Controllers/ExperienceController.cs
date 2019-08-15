using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Repository.Pattern.UnitOfWork;
using HMS.Service.Models;
using HMS.Entities.Models;

namespace HMS.Controllers
{
    public class ExperienceController : Controller
    {

        // private HMS.Entities.Models.HMSContext _context = new HMSContext();
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExperiencesService _iExperiencesService;
        public ExperienceController(IUnitOfWork unitOfWork, IExperiencesService iExperiencesService)
        {

            _iExperiencesService = iExperiencesService;
            _unitOfWork = unitOfWork;

        }
        public ActionResult Experience()
        {
         return View(_iExperiencesService.GetAllExperience());
        } 
        public ActionResult Index()
        {
            return View(_iExperiencesService.GetAllExperience());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Experience experience)
        {
            experience.Setdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _iExperiencesService.Insert(experience);
                _unitOfWork.SaveChanges();
               // TempData.Add("success", "Experience added successfully");
                return RedirectToAction("Index");

            }
            else
            {
                RedirectToAction("create");
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            return View(_iExperiencesService.Find(Id));
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Experience entity)
        {
            entity.Setdate = DateTime.Now;
            if (ModelState.IsValid)
            {

                _iExperiencesService.Update(entity);
                _unitOfWork.SaveChanges();
               // TempData.Add("success", "Experience updated successfully");
                return RedirectToAction("Index");

            }
            else
            {
                RedirectToAction("Edit");
            }
            return View("Index");
        }

        public ActionResult Details(int Id)
        {
            return View(_iExperiencesService.Find(Id));
        }

        public ActionResult Delete(int Id)
        {
            var experience = _iExperiencesService.Find(Id);
            if (experience != null)
            {               
                _iExperiencesService.Delete(Id);
                _unitOfWork.SaveChanges();
                TempData.Add("success", "Experience updated successfully");



            }
            else
            {
                RedirectToAction("Index");
            }
            return View("Index");
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
