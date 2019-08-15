using HMS.Admin.Utility;
using HMS.Service.Models;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using HMS.Entities.Models;
namespace HMS.Admin.Controllers
{
    public class AnswerChoiceController : Controller
    {
        private readonly IAnswerChoicesService _IAnswerChoicesService;
        private readonly IUnitOfWork _unitOfWork;

        public AnswerChoiceController(IAnswerChoicesService IAnswerChoicesService
            , IUnitOfWork unitOfWork

                        )
        {
            _IAnswerChoicesService = IAnswerChoicesService;
            _unitOfWork = unitOfWork;

        }
        [CustomActionFilterAttribute]
        public ActionResult Index(int? page, string searchItem, int questionId = 0)
        {
            var currentPageIndex = page.HasValue ? page.Value : 1;
            const int defaultPageSize = 10;
            IList<AnswerChoice> answerChoiceList = new List<AnswerChoice>();
            ViewData["searchItem"] = searchItem;

            answerChoiceList = (IList<AnswerChoice>)_IAnswerChoicesService.GetAnswerChoice(questionId).ToList();
            if (answerChoiceList.Count == 0)
            {
                var objanswerChoice = new AnswerChoice();
                objanswerChoice.QuestionId = questionId;
                answerChoiceList.Add(objanswerChoice);
            }
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                answerChoiceList = answerChoiceList.ToPagedList(currentPageIndex, defaultPageSize);
            }
            else
            {
                answerChoiceList = answerChoiceList.Where(p => p.WhyAnswerCorrect.ToString().Contains(searchItem.ToLower())
                    || p.QuestionId.ToString().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, defaultPageSize);
            }

            return View(answerChoiceList);
        }

        //
        // GET: /AnswerChoice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AnswerChoice/Create
        [CustomActionFilterAttribute]
        public ActionResult Create(int questionId = 0)
        {
            var objanswerChoice = new AnswerChoice();
            objanswerChoice.QuestionId = questionId;
            return View(objanswerChoice);
        }

        //
        // POST: /AnswerChoice/Create
        [HttpPost]
        [CustomActionFilterAttribute]
        public ActionResult Create(AnswerChoice objAnswerChoice)
        {
            try
            {
                _IAnswerChoicesService.Insert(objAnswerChoice);
                _unitOfWork.SaveChanges();
                TempData.Add("success", "Answer Choice Created Successfully.");
                return RedirectToAction("Index", new { questionId = objAnswerChoice.QuestionId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AnswerChoice/Edit/5
        [CustomActionFilterAttribute]
        public ActionResult Edit(int id)
        {
            var objAnswerChoice = _IAnswerChoicesService.Find(id);
            return View(objAnswerChoice);
        }

        //
        // POST: /AnswerChoice/Edit/5
        [HttpPost]
        [CustomActionFilterAttribute]
        public ActionResult Edit(AnswerChoice objAnswerChoice)
        {
            try
            {
                _IAnswerChoicesService.Update(objAnswerChoice);
                _unitOfWork.SaveChanges();
                TempData.Add("success", "Answer Choice Updated Successfully.");
                return RedirectToAction("Index", new { questionId = objAnswerChoice.QuestionId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AnswerChoice/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objAnswerChoice = _IAnswerChoicesService.Find(id);
            return View(objAnswerChoice);
        }

        //
        // POST: /AnswerChoice/Delete/5
        [HttpPost]
        [CustomActionFilterAttribute]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var objAnswerChoice = _IAnswerChoicesService.Find(id);
            try
            {

                _IAnswerChoicesService.Delete(id);
                _unitOfWork.SaveChanges();

                TempData.Add("success", "Answer Choice Deleted Successfully.");
                return RedirectToAction("Index", new { questionId = objAnswerChoice.QuestionId });
            }
            catch (Exception ex)
            {
                TempData.Add("danger", ex.Message.ToString());
                return RedirectToAction("Index", new { questionId = objAnswerChoice.QuestionId });
            }
        }
    }
}
