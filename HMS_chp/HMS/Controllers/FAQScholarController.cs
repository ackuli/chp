using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Models;
using HMS.ViewModels;

namespace HMS.Controllers
{
    public class FAQScholarController : Controller
    {
        //
        // GET: /FAQScholar/
        private HMS.Models.HMSContext _context = new HMSContext();
       

        //public ActionResult Askquestion()
        //{
        //    var lstTypes = new List<KeyValuePair<int, string>>();
        //    _context.QuestionTypes.ToList().ForEach(delegate(QuestionType item)
        //    {
        //        lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
        //    });
            
        //    QuestionAnswer objQuestionAnswer = new QuestionAnswer();
        //    objQuestionAnswer.Types = lstTypes;
        //    return View(objQuestionAnswer);
        //}
        //[HttpPost]
        //public ActionResult Askquestion(QuestionAnswer question)
        //{
        //    return View("Index");
        //}

    }
}
