using HMS.Admin.Utility;
using HMS.Entities.Models;
using HMS.Service.Models;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
namespace HMS.Admin.Controllers
{
    public class QuestionController : Controller
    {
       private readonly IQuestionsService _IQuestionsService;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionController(IQuestionsService IQuestionsService
            , IUnitOfWork unitOfWork           

                        )
        {
            _IQuestionsService = IQuestionsService;          
            _unitOfWork = unitOfWork;

        }
        [CustomActionFilterAttribute]
        public ActionResult Index(int? page, string searchItem)
        {
             var currentPageIndex = page.HasValue ? page.Value : 1;
            const int defaultPageSize = 10;          
            IList<Question> questionList = new List<Question>();
            ViewData["searchItem"] = searchItem;
           
                questionList = (IList<Question>)_IQuestionsService.GetAllQuestion().ToList();
                if (string.IsNullOrWhiteSpace(searchItem))
                {
                    questionList = questionList.ToPagedList(currentPageIndex, defaultPageSize);
                }
                else
                {
                    questionList = questionList.Where(p => p.QuestionText.ToString().ToLower().Contains(searchItem.ToLower())
                        ||p.QuestionId.ToString().ToLower().Contains(searchItem.ToLower()) ).ToPagedList(currentPageIndex, defaultPageSize);
                }
          
            return View(questionList);
        }
        [CustomActionFilterAttribute]
        public ActionResult QuestionView(int id = 0)
        {

            var question = _IQuestionsService.GetQuestionById(id);
            return View(question);
        }
        //
        // GET: /Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Question/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Question/Create
        [HttpPost]
        [CustomActionFilterAttribute]
        public ActionResult Create(Question objQuestion)
        {
            try
            {
                var questionId = _IQuestionsService.GetAllQuestion().Max(x => x.QuestionId);
                objQuestion.QuestionId=questionId+1;
              _IQuestionsService.Insert(objQuestion);
                _unitOfWork.SaveChanges();
                TempData.Add("success", "Question Created Successfully.");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Question/Edit/5
            [CustomActionFilterAttribute]
        public ActionResult Edit(int id)
        {
        var objQuestion= _IQuestionsService.Find(id);
            return View(objQuestion);
        }

        //
        // POST: /Question/Edit/5
        [HttpPost]
        [CustomActionFilterAttribute]
        public ActionResult Edit(Question objQuestion)
        {
            try
            {
              _IQuestionsService.Update(objQuestion);
                _unitOfWork.SaveChanges();
                TempData.Add("success", "Question Updated Successfully.");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Question/Delete/5
            [CustomActionFilterAttribute]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Question/Delete/5
        [HttpPost]
        [CustomActionFilterAttribute]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
