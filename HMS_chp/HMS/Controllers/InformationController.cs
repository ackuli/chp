using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    public class InformationController : Controller
    {
        //
        // GET: /Information/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult vedio()
        {
            return View(); 
        }
        public ActionResult HajjPortal()
        {
            return View();
        }
        public ActionResult UmrahPortal()
        {
            return View();
        }
        public ActionResult TravelGuaidSaudiAeabia()
        {
            return View();
        }
        public ActionResult SaftySecurityAndFraud()
        {
            return View();
        }
        public ActionResult IntroductiontoMadinah()
        {
            return View();
        }
        public ActionResult VisitingProphetMosque()
        {
            return View();
        }
        public ActionResult VisitingProphetGrave()
        {
            return View();
        }
        public ActionResult NotableSitesAroundMadinah()
        {
            return View();
        }

        public ActionResult PrayingatRiadulJannah()
        {
            return View();
        }

        public ActionResult UmrahandMiqat()
        {
            return View();
        }
        public ActionResult UmrahandIhram()
        {
            return View();
        }
        public ActionResult UmrahandSai()
        {
            return View();
        }
        //public ActionResult SaftySecurityAndFraud2()
        //{

        //    var fromAddress = new MailAddress("daud.cse@gmail.com");
        //    var fromPassword = "d01816514610";
        //    //var toAddress = new MailAddress("thesyed.london@gmail.com");
        //    var toAddress = new MailAddress("enquiry@comparehajjpackages.com");

        //    string subject = "subject";
        //    string body = fromAddress +"From contact message";

        //    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

        //    };

        //    using (var message = new MailMessage(fromAddress, toAddress)
        //    {
        //        Subject = subject,
        //        Body = body
        //    })


        //        smtp.Send(message);
           
        //    return View();
        //}
    }
}
