using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Service.Models;
using HMS.Entities.Models;
using Repository.Pattern.UnitOfWork;
using MvcPaging;
using HMS.Entities.ViewModels;
using System.Net.Mail;
using System.Net;
using HMS.Utility;
using HMS.Admin.Utility;
namespace HMS.Controllers
{
    public class QuestionAnswerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionAnswersService _iQuestionAnswersService;
        private readonly IScholareService _scholarService;
        private readonly IQuestionTypeService _questionTypeService;
        public QuestionAnswerController(IUnitOfWork unitOfWork, IQuestionAnswersService iQuestionAnswersService, IScholareService scholarService
            ,IQuestionTypeService questionTypeService)
        {
            _scholarService = scholarService;
            _iQuestionAnswersService = iQuestionAnswersService;
            _questionTypeService = questionTypeService;
            _unitOfWork = unitOfWork;

        }
        public ActionResult Index(int? page, string searchItem)
        {

            const int defaultPageSize = 10;
            ViewData["searchItem"] = searchItem;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<QuestionAnswer> lstQuestionAnswer = _iQuestionAnswersService.GetAllQuestionAnswer().OrderBy(x => x.EntryDate).ToList();
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                lstQuestionAnswer = lstQuestionAnswer.ToPagedList(currentPageIndex, defaultPageSize);
            }
            else
            {
                lstQuestionAnswer = lstQuestionAnswer.Where(p => p.Question.ToLower().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, defaultPageSize);
            }
            return View(lstQuestionAnswer);

        }

        public ActionResult IndexQuestionAnswer(int? page, string searchItem)
        {

            const int defaultPageSize = 10;
            ViewData["searchItem"] = searchItem;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<QuestionAnswer> lstQuestionAnswer = _iQuestionAnswersService.GetAllQuestionAnswer().OrderBy(x => x.EntryDate).ToList();
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                lstQuestionAnswer = lstQuestionAnswer.ToPagedList(currentPageIndex, defaultPageSize);
            }
            else
            {
                lstQuestionAnswer = lstQuestionAnswer.Where(p => p.Question.ToLower().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, defaultPageSize);
            }
            return View(lstQuestionAnswer);

        }
       
        public ActionResult IndexForClient()
        {
            VmSchQuesAns vmSchQuesAns = new VmSchQuesAns();

            vmSchQuesAns.quesAns = new QuestionAnswer();
            vmSchQuesAns.scholareList = new List<Scholare>();

            vmSchQuesAns.scholareList = _scholarService.GetActiveScholare(true).Select(r => new Scholare { ScholarId=r.ScholarId, ScholarName=r.ScholarName }).ToList();
            
            var objAskedScholarVm = new QuestionAnswer
            {
                RecentQuestionAnswersList =
                    _iQuestionAnswersService.GetVisibleQuestionAnswer(true).OrderBy(x => x.Count)
                    .Take(5)
                    .ToList().OrderBy(x => x.EntryDate).ToList(),
                FAQ = _iQuestionAnswersService.GetFrequentAskQuestionAnswer(true, true)
                .Where(x => x.IsFrequentAsk == true)
                .Take(5).ToList()
                .OrderBy(x => x.EntryDate).ToList()
            };

            vmSchQuesAns.quesAns = objAskedScholarVm;
            vmSchQuesAns.quesAns.kvpQuestionType = _questionTypeService.KVPGetQuestionType();

            return View(vmSchQuesAns);
        }

        public ActionResult ScholarDetails(int id)
        {
            Scholare sch = new Scholare();
            sch = _scholarService.GetScholareById(id);
            return View(sch);
        }
        public ActionResult FrequentAskQuestion(int? page)
        {

            int PAGE_SIZE = 10;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            var questionAnswers = _iQuestionAnswersService.GetFrequentAskQuestionAnswer(true,true);
            questionAnswers = (IPagedList<QuestionAnswer>)questionAnswers.ToList().ToPagedList(currentPageIndex, PAGE_SIZE);
            return View(questionAnswers);
        }
        public ActionResult RecentQuestionAnswers(int? page)
        {
            int PAGE_SIZE = 10;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            var questionAnswers = _iQuestionAnswersService.GetVisibleQuestionAnswer(true);
            questionAnswers = (IPagedList<QuestionAnswer>)questionAnswers.ToList().ToPagedList(currentPageIndex, PAGE_SIZE);
            return View(questionAnswers);
        }

        public ActionResult QuestionDetails(int id)
        {
            var questionAnswers = _iQuestionAnswersService.Find(id);
            return View(questionAnswers);
        }
         [RecaptchaFilter]
        public ActionResult CreateForClient(bool IsShowMgs = false)
        {
            if (IsShowMgs)
            {
                ViewBag.Success = true;
                ViewBag.Message = "Question successfully added.";
            }
            else
            {
                ViewBag.Success = null;
                ViewBag.Message = "Invalid reCaptcha.";
            }                
            var objQuestionAnswer = _iQuestionAnswersService.newQuestionAnswer();

            return View(objQuestionAnswer);
        }
         public JsonResult GetQuestionCategory()
         {
             var result = _questionTypeService.KVPGetQuestionType();
             return Json(result, JsonRequestBehavior.AllowGet);
         }
        [HttpPost]
        [ValidateInput(false)]
        [RecaptchaFilter]
        public ActionResult CreateFromClient(QuestionAnswer questionAnswer, bool CaptchaValid)
        {

            if (!CaptchaValid)
            {
                ViewBag.Success = false;
                ViewBag.Message = "Invalid reCaptcha";
                var objQuestionAnswer = _iQuestionAnswersService.newQuestionAnswer();
                questionAnswer.kvpQuestionType = objQuestionAnswer.kvpQuestionType;
                return View("CreateForClient", questionAnswer);
            }
            questionAnswer.IsSelfInitiative = false;//from client
            questionAnswer.IsVisible = false;
            questionAnswer.EntryDate = DateTime.Now;
            //questionAnswer.AnswerDate = DateTime.Now;
            questionAnswer.SetDate = DateTime.Now;
            try
            {
                _iQuestionAnswersService.Insert(questionAnswer);
                _unitOfWork.SaveChanges();
                ViewBag.Success = true;


              // var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                //mailer.Body = "Thanks for Registering your account.<br> please verify your email id by clicking the link <br> <a href='youraccount.com/verifycode=12323232'>verify</a>";
                var fromAddress = new MailAddress("fromchp@gmail.com");
                var fromPassword = "UltimateMegamind2014?";
                //var toAddress = new MailAddress("thesyed.london@gmail.com");
                var toAddress = new MailAddress("question@comparehajjpackages.com");
                string subject = "subject";
                string body = questionAnswer.Name + questionAnswer.EmailId + questionAnswer.KeyWords + questionAnswer.Question;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                smtp.Send(message);
                //  ViewBag.Message = "Employee successfully added";

            }
            catch (Exception mgs)
            {
            }
            return RedirectToAction("CreateForClient", new { IsShowMgs = ViewBag.Success });
        }
        public ActionResult CreateSearchCategoryForClient(int? page, string TypeId, string searchItem)
        {
            var varCategooryTypeId = TypeId == null ? 0 : Convert.ToInt32(TypeId);
            QuestionAnswer rtnQuestionAnswer = new QuestionAnswer();
            rtnQuestionAnswer.CategoryWiseQuestionAnswersList =
                _iQuestionAnswersService.GetQuestionAnswerByCategory(varCategooryTypeId, searchItem);
            var questionAnswer = _iQuestionAnswersService.newQuestionAnswer();
            rtnQuestionAnswer.kvpQuestionType = questionAnswer.kvpQuestionType;
            return View(rtnQuestionAnswer);
        }
        public ActionResult SearchByKeyWords(int? page, string searchItem)
        {

            var questionAnswer = _iQuestionAnswersService.GetQuestionAnswerByKeyWords(searchItem);
            return View(questionAnswer);
        }
        public ActionResult CreateSearchByKeyWords()
        {
            List<QuestionAnswer> rtnQuestionAnswer = new List<QuestionAnswer>();
            return View("SearchByKeyWords", rtnQuestionAnswer);
        }
        //[ValidateInput(false)]
        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SearchCategoryWiseForClient(QuestionAnswer questionAnswer)
        {
            return View("CreateSearchCategoryForClient");
        }

        public ActionResult Create()
        {
            var objQuestionAnswer = _iQuestionAnswersService.newQuestionAnswer();
            return View(objQuestionAnswer);
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(QuestionAnswer questionAnswer)
        {

            try
            {
                questionAnswer.IsSelfInitiative = true;//from user
                // questionAnswer.IsVisible = false;
                questionAnswer.EntryDate = DateTime.Now;
                questionAnswer.SetDate = DateTime.Now;
                _iQuestionAnswersService.Insert(questionAnswer);
                _unitOfWork.SaveChanges();
            }
            catch (Exception mgs)
            {
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            QuestionAnswer questionAnswer = _iQuestionAnswersService.Find(Id);
            var objQuestionAnswer = _iQuestionAnswersService.newQuestionAnswer();
            questionAnswer.kvpQuestionType = objQuestionAnswer.kvpQuestionType;
            return View(questionAnswer);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(QuestionAnswer questionAnswer)
        {
            questionAnswer.SetDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _iQuestionAnswersService.Update(questionAnswer);
                _unitOfWork.SaveChanges();
            }
            else
            {

            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            return View(_iQuestionAnswersService.Find(Id));
        }

        public ActionResult DetailsForClient(int Id)
        {
            return View(_iQuestionAnswersService.Find(Id));
        }
        public ActionResult Delete(int Id)
        {
            var objQuestionAnswer = _iQuestionAnswersService.Find(Id);

            return View(objQuestionAnswer);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var objQuestionAnswer = _iQuestionAnswersService.Find(id);
                _iQuestionAnswersService.Delete(objQuestionAnswer);
                _unitOfWork.SaveChanges();
                TempData.Add("Success", "Delete Question Successfully.");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
