using HMS.Entities.Models;
using HMS.Service.Models;
using HMS.Utility;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    public class ContactUsController : Controller
    {




        private readonly IUnitOfWork _unitOfWork;
        private readonly IContactUsService _iContactUsService;

        public ContactUsController(IUnitOfWork unitOfWork, IContactUsService iContactUsService)
        {
            _unitOfWork = unitOfWork;
            _iContactUsService = iContactUsService;
        }
        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContactUs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactUs/Create
        [RecaptchaFilter]
        public ActionResult Create(bool IsShowMgs = false)
        {


            if (IsShowMgs)
            {
                ViewBag.Success = true;
                ViewBag.Message = "Your web enquiry submission has been successful.";
            }
            else
            {
                ViewBag.Success = null;
                ViewBag.Message = "Invalid reCaptcha.";
            }

            return View("CreateFromClient");
        }

        // POST: ContactUs/Create
        [HttpPost]
        [RecaptchaFilter]
        public ActionResult Create(ContactU contactU, bool CaptchaValid)
        {
            if (!CaptchaValid)
            {
                ViewBag.Success = false;
                ViewBag.Message = "Invalid reCaptcha";
                //  ModelState.AddModelError("reCaptcha", "Invalid reCaptcha");
                // return RedirectToAction("Create", new { IsShowMgs = ViewBag.Success });
                return View("CreateFromClient", contactU);
            }

            contactU.LastUpdateTime = DateTime.Now;
            contactU.IsActive = true;
            contactU.Subject = "from client";
            contactU.Captcha = "";

            if (ModelState.IsValid)
            {
                _iContactUsService.Insert(contactU);
                _unitOfWork.SaveChanges();
                ViewBag.Success = true;
                //var fromAddress = new MailAddress("syed.shahriar@comparehajjpackages.com");
                //var fromPassword = "100%UltimateMegamind619";
               // var fromAddress = new MailAddress("daud.cse@gmail.com");
                var fromAddress = new MailAddress("fromchp@gmail.com");

                var fromPassword = "UltimateMegamind2014?";
               // var fromPassword = "d01816514610";
                //var toAddress = new MailAddress("thesyed.london@gmail.com");
                var toAddress = new MailAddress("enquiry@comparehajjpackages.com");
                string subject = "subject";
                string body = contactU.Name + contactU.Email + contactU.Message + contactU.Subject;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

                };
                using (var message1 = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                    smtp.Send(message1);
                return RedirectToAction("Create", new { IsShowMgs = ViewBag.Success });
            }
            else
            {
                ViewBag.Success = false;

                return RedirectToAction("Create", new { IsShowMgs = ViewBag.Success });
            }
        }

        // GET: ContactUs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactUs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactUs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactUs/Delete/5
        [HttpPost]
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
