using HMS.Admin.Utility;
using HMS.Entities.Models;
using HMS.Service.Models;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Admin.Controllers
{
    public class QuizQuestionAnswerController : Controller
    {
          private readonly IQuizQuestionAnswersService _IQuizQuestionAnswersService;
        private readonly IUnitOfWork _unitOfWork;

        public QuizQuestionAnswerController(IQuizQuestionAnswersService IQuizQuestionAnswersService
            , IUnitOfWork unitOfWork           

                        )
        {
            _IQuizQuestionAnswersService = IQuizQuestionAnswersService;          
            _unitOfWork = unitOfWork;

        }
        [CustomActionFilterAttribute]
        public ActionResult Index(int questionId = 0)
        {
            var objQuizQuestionAnswers=_IQuizQuestionAnswersService.GetQuizQuestionAnswerByQuestionId(questionId).ToList();
            if (objQuizQuestionAnswers.Count == 0)
            {
                var objQuizQuestionAnswer = new QuizQuestionAnswer();
                objQuizQuestionAnswer.QuestionId = questionId;
                objQuizQuestionAnswers.Add(objQuizQuestionAnswer);
            }
            return View(objQuizQuestionAnswers);
        }

        //
        // GET: /QuizQuestionAnswer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /QuizQuestionAnswer/Create
            [CustomActionFilterAttribute]
        public ActionResult Create(int questionId = 0)
        {
            var objQuizQuestionAnswer = new QuizQuestionAnswer();
            objQuizQuestionAnswer.QuestionId = questionId;
            var newobjQuizQuestionAnswer=  _IQuizQuestionAnswersService.newQuizQuestionAnswer(questionId);
            objQuizQuestionAnswer.kvpAnswerChoice = newobjQuizQuestionAnswer.kvpAnswerChoice;
            return View(objQuizQuestionAnswer);
        }
        //
        // POST: /QuizQuestionAnswer/Create
        [HttpPost]
        [CustomActionFilterAttribute]
        public ActionResult Create(QuizQuestionAnswer objQuizQuestionAnswer)
        {
            try
            {
                var objQuizQuestionAnswerFind = _IQuizQuestionAnswersService.GetQuizQuestionAnswerByQuestionId(objQuizQuestionAnswer.QuestionId);
                if (objQuizQuestionAnswerFind.ToList().Count!=0)
                {
                    TempData.Add("success", "Quiz Question Answer Already Added.");
                    return RedirectToAction("Index", new { questionId = objQuizQuestionAnswer.QuestionId });
                }
                _IQuizQuestionAnswersService.Insert(objQuizQuestionAnswer);
                _unitOfWork.SaveChanges();
                TempData.Add("success", "Quiz Question Answer Created Successfully.");
                return RedirectToAction("Index", new { questionId = objQuizQuestionAnswer.QuestionId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /QuizQuestionAnswer/Edit/5
            [CustomActionFilterAttribute]
        public ActionResult Edit(int id)
        {
            var objQuizQuestionAnswer= _IQuizQuestionAnswersService.Find(id);
          var newobjQuizQuestionAnswer=  _IQuizQuestionAnswersService.newQuizQuestionAnswer(objQuizQuestionAnswer.QuestionId);

          objQuizQuestionAnswer.kvpAnswerChoice = newobjQuizQuestionAnswer.kvpAnswerChoice;
            return View(objQuizQuestionAnswer);
        }

        //
        // POST: /QuizQuestionAnswer/Edit/5
        [HttpPost]
        [CustomActionFilterAttribute]
        public ActionResult Edit(QuizQuestionAnswer objQuizQuestionAnswer)
        {
            try
            {
                // TODO: Add update logic here
                _IQuizQuestionAnswersService.Update(objQuizQuestionAnswer);
                TempData.Add("success", "Quiz Question Answer Updated Successfully.");
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index", new { questionId = objQuizQuestionAnswer.QuestionId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /QuizQuestionAnswer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /QuizQuestionAnswer/Delete/5
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
