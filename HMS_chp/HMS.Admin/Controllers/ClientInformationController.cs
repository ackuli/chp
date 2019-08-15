using HMS.Admin.Utility;
using HMS.Entities.Models;
using HMS.Admin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Admin.Controllers
{
    public class ClientInformationController : Controller
    {
        // GET: ClientInformation
        public ActionResult ClientInfoList()
        {
            return View();
        }

        // GET: ClientInformation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientInformation/Create

        [CustomActionFilterAttribute]
        public ActionResult ClientInfoCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientInfoCreate([Bind(Include = "ClientInfoId,ClientId,Address,Tellandline,TelMobile,Email , Website , YearEstablished  , IsApprovedbySaudiHajjMinistry ,MinistryApprovalNumber ,Approvedfor , ATOLApproved , ATOLLicense , IATANo , CompanyRegistrationNumber , Remarks , SetBy , SetDate , LastUpdateDate")] ClientInformation clientInformation)
        {
            return View();
        }       
        // GET: ClientInformation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomActionFilterAttribute]
        public ActionResult EditclientInformation(int id)
        {
            return View();
        }

        // POST: ClientInformation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomActionFilterAttribute]
        public ActionResult EditclientInformation([Bind(Include = "ClientInfoId,ClientId,Address,Tellandline,TelMobile,Email , Website , YearEstablished  , IsApprovedbySaudiHajjMinistry ,MinistryApprovalNumber ,Approvedfor , ATOLApproved , ATOLLicense , IATANo , CompanyRegistrationNumber , Remarks , SetBy , SetDate , LastUpdateDate")] ClientInformation clientInformation)
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

        // GET: ClientInformation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientInformation/Delete/5
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
