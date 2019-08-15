using HMS.Entities.Models;
using HMS.Service.Models;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionsService _iQuestionsService;
        private readonly IQuizsService _iQuizsService;
        private readonly IQuizDetailsService _iQuizDetailsService;
        private readonly IAnswerChoicesService _iAnswerChoicesService;
        private readonly IAnswersService _iAnswerService;

        public QuestionController(IUnitOfWork unitOfWork, IQuestionsService iQuestionsService
            , IQuizsService iQuizsService,
            IQuizDetailsService iQuizDetailsService
            , IAnswerChoicesService iAnswerChoicesService
            , IAnswersService iAnswerService)
        {
            _unitOfWork = unitOfWork;
            _iQuestionsService = iQuestionsService;
            _iQuizsService = iQuizsService;
            _iQuizDetailsService = iQuizDetailsService;
            _iAnswerChoicesService = iAnswerChoicesService;
            _iAnswerService = iAnswerService;
        }
        // GET: /Question/
        public ActionResult quizresult(int QuizId = 0)
        {

            var QuizDetails = _iQuizDetailsService.GetQuizDetail(QuizId);
            return View(QuizDetails);
        }
        public ActionResult checkyouranswer(int QuizId = 0)
        {

            var QuizDetails = _iQuizDetailsService.checkyouranswer(QuizId);
            return View(QuizDetails);
        }

        public ActionResult quiz()
        {
            return View();
        }
        [HttpGet]
        public ActionResult quiztest(int quizId=0)
        {
            Quiz objQuiz = new Quiz();
            //var QuestionId ;
            if (quizId == 0)
            {
                objQuiz.Score = 0;
                objQuiz.StartTime = DateTime.Now;
                objQuiz.EndTime = DateTime.Now;
                objQuiz.IsActive = false;
                _iQuizsService.Insert(objQuiz);
                _unitOfWork.SaveChanges();                
            }
            else
            {
                Quiz objQuizNext = new Quiz();
                //Insert New Quiz
                objQuizNext.Score = 0;
                objQuizNext.StartTime = DateTime.Now;
                objQuizNext.EndTime = DateTime.Now;
                objQuizNext.IsActive = false;
                _iQuizsService.Insert(objQuizNext);
                _unitOfWork.SaveChanges();    
       
                //Update Current Quiz
                 objQuiz=_iQuizsService.Find(quizId);
                 objQuiz.PreQuizRefId = objQuizNext.QuizId;
                _iQuizsService.Update(objQuiz);
                _unitOfWork.SaveChanges();
                objQuiz.QuizId = objQuizNext.QuizId;
               
            }
            var QuestionId = _iQuestionsService.NextQuizRandom(objQuiz.QuizId, 0);
            var objQuestionNext = _iQuestionsService.GetQuestionById(Convert.ToInt32(QuestionId));
            objQuestionNext.QuizId = objQuiz.QuizId;
            objQuestionNext.QuestionSLNo = 1;
            return View(objQuestionNext);
        }
        [HttpPost]
        public ActionResult quiztest(Question objQuestion, string Answer)
        {
            Quiz objQuiz = new Quiz();
                     
            if (Answer != null)
            {
                var objQuestionCurrent = _iQuestionsService.GetQuestionById(objQuestion.QuestionId);
                var objQuizDetails = new QuizDetail();
                var objAnswerChoice = objQuestionCurrent.AnswerChoices.Where(x => x.QuestionId == objQuestion.QuestionId && x.Choices == Answer).SingleOrDefault();
                var objQuizQuestionAnswer = objQuestionCurrent.QuizQuestionAnswers.Where(x => x.QuestionId == objQuestion.QuestionId).SingleOrDefault();

                objQuizDetails.GivenAnswerChoiceId = objAnswerChoice.AnswerChoiceId;
                objQuizDetails.CorrectAnswerChoiceId = objQuizQuestionAnswer.AnswerChoiceId;
                objQuizDetails.QuizId = objQuestion.QuizId == null ? 0 : Convert.ToInt32(objQuestion.QuizId);
                objQuizDetails.QuestionId = objQuestion.QuestionId;
                if (objQuizQuestionAnswer == null)
                {
                    objQuizDetails.Score = 0;
                }
                else
                {

                    if (objQuizQuestionAnswer.AnswerChoiceId == objAnswerChoice.AnswerChoiceId)
                    {

                        objQuizDetails.Score = 1;
                    }
                    else
                    {
                        objQuizDetails.Score = 0;
                    }

                }
                _iQuizDetailsService.Insert(objQuizDetails);
                _unitOfWork.SaveChanges();
            }
            if (Answer == null && objQuestion.QuestionId != 0)
            {
                var objQuestionCurrent = _iQuestionsService.GetQuestionById(objQuestion.QuestionId);
                var objQuizQuestionAnswer = objQuestionCurrent.QuizQuestionAnswers.Where(x => x.QuestionId == objQuestion.QuestionId).SingleOrDefault();
                var objQuizDetails = new QuizDetail();
                objQuizDetails.GivenAnswerChoiceId = null;
                objQuizDetails.CorrectAnswerChoiceId = objQuizQuestionAnswer.AnswerChoiceId;
                objQuizDetails.QuizId = objQuestion.QuizId == null ? 0 : Convert.ToInt32(objQuestion.QuizId);
                objQuizDetails.QuestionId = objQuestion.QuestionId;
                objQuizDetails.Score = 0;
                _iQuizDetailsService.Insert(objQuizDetails);
                _unitOfWork.SaveChanges();

            }
            var objQuestionNext = new Question();
            if (objQuestion == null)
            {
                objQuestion = new Question();
            }
            var QuestionId = _iQuestionsService.NextQuizRandom(objQuestion.QuizId == null ? 0 : Convert.ToInt32(objQuestion.QuizId), objQuestion.QuestionId);
          
            //objQuestionNext.QuestionId = objQuestion.QuestionId + 1;
             objQuestionNext = _iQuestionsService.GetQuestionById(Convert.ToInt32(QuestionId));

            if (objQuestionNext == null)
            {
                return RedirectToAction("quizResult", new { QuizId = objQuestion.QuizId });
            }
            objQuestionNext.QuizId = objQuestion.QuizId;
            objQuestionNext.QuestionSLNo = objQuestion.QuestionSLNo + 1;            
            return View(objQuestionNext);
        }
        public ActionResult HajjAndUmmrahRelatedQuestion()
        {
            return View();
        }


    }
}
