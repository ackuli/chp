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
    public class QuestionDetailController : Controller
    {
        private readonly IQuestionDetailsService _IQuestionDetailsService;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionDetailController(IQuestionDetailsService IQuestionDetailsService
            , IUnitOfWork unitOfWork           

                        )
        {
            _IQuestionDetailsService = IQuestionDetailsService;          
            _unitOfWork = unitOfWork;

        }
        [CustomActionFilterAttribute]
        public ActionResult Index(int? page, string searchItem, int questionId = 0)
        {
            var currentPageIndex = page.HasValue ? page.Value : 1;
            const int defaultPageSize = 10;
            IList<QuestionDetail> questionDetailList = new List<QuestionDetail>();
            ViewData["searchItem"] = searchItem;

            questionDetailList = (IList<QuestionDetail>)_IQuestionDetailsService.GetQuestionDetailByQuestionId(questionId).ToList();
            if (questionDetailList.Count==0)
            {
                var questionDetail = new QuestionDetail();
                questionDetail.QuestionId = questionId;
                questionDetailList.Add(questionDetail);
            }
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                questionDetailList = questionDetailList.ToPagedList(currentPageIndex, defaultPageSize);
            }
            else
            {
                questionDetailList = questionDetailList.Where(p => p.QuestionId.ToString().Contains(searchItem.ToLower())
                    || p.QuestionId.ToString().Contains(searchItem.ToLower())
                    || p.QuestionDetailsText.ToString().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, defaultPageSize);
            }

            return View(questionDetailList);
        }
        //
        // GET: /QuestionDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /QuestionDetail/Create

            [CustomActionFilterAttribute]
        public ActionResult Create(int questionId = 0)
        {
            var objquestionDetail = new QuestionDetail();
            objquestionDetail.QuestionId = questionId;
            return View(objquestionDetail);
        }

        //
        // POST: /QuestionDetail/Create
        [HttpPost]
        [CustomActionFilterAttribute]
        public ActionResult Create(QuestionDetail objQuestionDetail)
        {
            try
            {
                _IQuestionDetailsService.Insert(objQuestionDetail);
                _unitOfWork.SaveChanges();
                TempData.Add("success", "Question Detail Created Successfully.");
                return RedirectToAction("Index", new { questionId = objQuestionDetail.QuestionId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /QuestionDetail/Edit/5
            [CustomActionFilterAttribute]
        public ActionResult Edit(int id)
        {
            var objquestiondeatils= _IQuestionDetailsService.Find(id);
           
            return View(objquestiondeatils);
        }

        //
        // POST: /QuestionDetail/Edit/5
        [HttpPost]
        [CustomActionFilterAttribute]
        public ActionResult Edit(QuestionDetail objQuestionDetail)
        {
            try
            {
                // TODO: Add update logic here
                _IQuestionDetailsService.Update(objQuestionDetail);
                _unitOfWork.SaveChanges();
                TempData.Add("success", "Question Detail Updated Successfully.");
                return RedirectToAction("Index", new { questionId = objQuestionDetail.QuestionId });
                
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
            var objQuestionDetail = _IQuestionDetailsService.Find(id);
            return View(objQuestionDetail);
        }

        //
        // POST: /AnswerChoice/Delete/5
        [HttpPost]
        [CustomActionFilterAttribute]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var objQuestionDetail = _IQuestionDetailsService.Find(id);
            try
            {
               
                _IQuestionDetailsService.Delete(id);
                _unitOfWork.SaveChanges();

                TempData.Add("success", "Question Detail Deleted Successfully.");
                return RedirectToAction("Index", new { questionId = objQuestionDetail.QuestionId });
            }
            catch (Exception ex)
            {
                TempData.Add("danger", ex.Message.ToString());
                return RedirectToAction("Index", new { questionId = objQuestionDetail.QuestionId });
            }
        }
    }
}
