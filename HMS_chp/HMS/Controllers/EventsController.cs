using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using HMS.Service.Models;
using Repository.Pattern.UnitOfWork;
using System.IO;
using HMS.Entities.Models;
using HMS.Entities.ViewModels;
using System.Net.Mail;
using System.Net;
using HMS.Utility;

namespace HMS.Controllers
{
    public class EventsController : Controller
    {
        private HMS.Entities.Models.HMSContext _context = new HMSContext();

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventService _iEventService;
        private readonly IBinaryObjectService _iBinaryObjectService;
        public EventsController(IUnitOfWork unitOfWork
            , IEventService iEventService
            , IBinaryObjectService iBinaryObjectService)
        {

            _iEventService = iEventService;
            _unitOfWork = unitOfWork;
            _iBinaryObjectService = iBinaryObjectService;

        }
        // GET: /Events/
        private const int PAGE_SIZE = 6;
        public ActionResult Index(int? page, string searchItem)
        {

            ViewData["searchItem"] = searchItem;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<HMS.Entities.Models.Event> lstEvent = _iEventService.GetAllEvent().OrderByDescending(x => x.EventsDate).ToList();
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                lstEvent = lstEvent.ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            else
            {
                lstEvent = lstEvent.Where(p => p.EventsTitle.ToLower().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            return View(lstEvent);
        }
        public ActionResult IndexForClient(int? page, string searchItem)
        {

            ViewData["searchItem"] = searchItem;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<HMS.Entities.Models.Event> lstEvent = _iEventService.GetActivEvent(true).OrderByDescending(x => x.EventsDate).ToList();
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                lstEvent = lstEvent.ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            else
            {
                lstEvent = lstEvent.Where(p => p.EventsTitle.ToLower().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            return View(lstEvent);
        }


        public ActionResult Details(int id)
        {
            HMS.Entities.Models.Event objevent = _iEventService.GetEventById(id);
            return View(objevent);
        }
        public FileResult DocView(int id)
        {
            string path = "~//binaryObj//" + id.ToString() + _context.BinaryObjects.Where(x => x.BinaryObjectsId == id).FirstOrDefault().Name +
                          _context.BinaryObjects.Where(x => x.BinaryObjectsId == id).FirstOrDefault().Extension;

            return File(path, "application/pdf");
        }

        public ActionResult EventsList(string EventsTypeId, int? page)
        {                 
            int currentPageIndex = page.HasValue ? page.Value : 1;
            var objEventsList= _iEventService.GetActivEvent(true);
            objEventsList = string.IsNullOrWhiteSpace(EventsTypeId) ? objEventsList.OrderBy(x => x.EventsDate).ToList().ToPagedList(currentPageIndex, PAGE_SIZE) : objEventsList.Where(p => p.EventsTitle.ToLower().Contains(EventsTypeId.ToLower())).ToPagedList(currentPageIndex, PAGE_SIZE);
            objEventsList = (IPagedList<Event>)objEventsList;
            return View(objEventsList);
        }
        public ActionResult ArchiveEventsList(string EventsTypeId, int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            var objEventsList = _iEventService.GetArchiveEvent(true);
            objEventsList = string.IsNullOrWhiteSpace(EventsTypeId) ? objEventsList.ToList().ToPagedList(currentPageIndex, PAGE_SIZE) : objEventsList.Where(p => p.EventsTitle.ToLower().Contains(EventsTypeId.ToLower())).ToPagedList(currentPageIndex, PAGE_SIZE);
            objEventsList = (IPagedList<Event>)objEventsList;
            return View(objEventsList);
            
        }
         [RecaptchaFilter]
        public ActionResult create()
        {
            EventVM objEventVM = new EventVM();
            var newEvent = _iEventService.newEvent();
            objEventVM.Event = newEvent;
            //objEventVM.Event.StartDate = DateTime.Now;
            //objEventVM.Event.EndDate = DateTime.Now;
            return View(objEventVM);
        }
        public ActionResult createFromClient(bool IsSucess=false)
        {
            EventVM objEventVM = new EventVM();
            var newEvent = _iEventService.newEvent();
            objEventVM.Event = newEvent;
            objEventVM.Event.EventsDate = DateTime.Now;
          //  objEventVM.Event.EventsDate = DateTime.Parse(objEventVM.Event.EventsDate.ToString("dd/MM/yyyy"));
            objEventVM.Event.StartDate =null;
            objEventVM.Event.EndDate = null;
            if (IsSucess)
            {

                ViewBag.Success = true;
                ViewBag.Message = "Event added successfully.";
            }
            return View(objEventVM);
        }
        public byte[] ConvertsToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        [HttpPost]
        [RecaptchaFilter]
        public ActionResult createFromClient(EventVM objevent,bool CaptchaValid)
        {
             if (!CaptchaValid)
            {
                ViewBag.Success = false;
                ViewBag.Message = "Invalid reCaptcha";

                View("createFromClient", objevent);
            }


            ActionResult rtn = View();
            BinaryObject objbinaryObject = new HMS.Entities.Models.BinaryObject();           
            objevent.Event.EventsDate = DateTime.Now;                   
            try
            {

                if (ModelState.IsValid)
                {
                    objevent.Event.IsVisible = false;
                    objevent.Event.IsArchive = false;
                    //  objevent.Event.SetBy = "Admin";
                  //  objevent.Event.EventsDate = objevent.Event.EventsDate;
                    //objevent.Event.StartDate = Convert.ToDateTime(objevent.Event.StartDate.Value.ToString("yyyy-MM-dd h:mm tt"));
                    //objevent.Event.EndDate = Convert.ToDateTime(objevent.Event.EndDate.Value.ToString("yyyy-MM-dd h:mm tt"));

                    _iEventService.Insert(objevent.Event);
                    _unitOfWork.SaveChanges();

                    if (objevent.EventDoc1 != null && objevent.EventDoc1.ContentLength > 0 && objevent.EventDoc1.FileName.Substring(objevent.EventDoc1.FileName.Length - 4, 4).ToLower() == ".pdf")
                    {
                        var imagebyte = ConvertsToBytes(objevent.EventDoc1);
                        objbinaryObject.Object = imagebyte;
                        objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.EventDoc;
                        objbinaryObject.Name = objevent.EventDoc1.FileName;
                        objbinaryObject.RefObjectKey = objevent.Event.EventsId;
                        objbinaryObject.Extension = objevent.EventDoc1.ContentType;
                        _iBinaryObjectService.Insert(objbinaryObject);
                        _unitOfWork.SaveChanges();
                    }
                    if (objevent.Logo != null && objevent.Logo.ContentLength > 0)
                    {
                        var imagebyte = ConvertsToBytes(objevent.Logo);
                        objbinaryObject.Object = imagebyte;
                        objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.EventLogo;
                        objbinaryObject.Name = objevent.Logo.FileName;
                        objbinaryObject.RefObjectKey = objevent.Event.EventsId;
                        objbinaryObject.Extension = objevent.Logo.ContentType;
                        _iBinaryObjectService.Insert(objbinaryObject);
                        _unitOfWork.SaveChanges();
                    }
                    var fromAddress = new MailAddress("fromchp@gmail.com");
                    var fromPassword = "UltimateMegamind2014?";                    
                    var toAddress = new MailAddress("listyourevent@comparehajjpackages.com");
                    string subject = "subject";
                    string body ="<p>Event Name:"+objevent.Event.EventsTitle+"</p><br/><p>Name:"+objevent.Event.YourName+"</p><br/><p>Organisation:" +objevent.Event.YourOrganisation+"</p>";

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
                    EventVM objEventVM = new EventVM();
                    var newEvent = _iEventService.newEvent();
                    objEventVM.Event = newEvent;
                   
                    rtn = RedirectToAction("createFromClient", new { IsSucess = true });
                    //  trun.Commit();
                }
                else
                {
                    EventVM objEventVM = new EventVM();
                    var newEvent = _iEventService.newEvent();
                    objEventVM.Event = newEvent;
                    ViewBag.Success = true;
                    ViewBag.Message = "Model is not valid.";
                    rtn = View("createFromClient", objEventVM);
                    //  trun.Rollback();
                }
            }
            catch (Exception ex)
            {
                EventVM objEventVM = new EventVM();
                var newEvent = _iEventService.newEvent();
                objEventVM.Event = newEvent;
                ViewBag.Success = false;
                ViewBag.Message = ex.Message;
                rtn = View("createFromClient", objEventVM);
                //  trun.Rollback();
            }
            // }



            return rtn;
        }

        [HttpPost]
        public ActionResult create(EventVM objevent)
        {
            ActionResult rtn = View();
            BinaryObject objbinaryObject = new HMS.Entities.Models.BinaryObject();
            //using (var trun = _unitOfWork.BeginTransaction()
            //{
            try
            {

                if (ModelState.IsValid)
                {
                    //objevent.Event.IsVisible = false;
                    //objevent.Event.IsArchive = false;
                    //  objevent.Event.SetBy = "Admin";
                    objevent.Event.EventsDate = objevent.Event.EventsDate;
                    //objevent.Event.StartDate = Convert.ToDateTime(objevent.Event.StartDate.Value.ToString("yyyy-MM-dd h:mm tt"));
                    //objevent.Event.EndDate = Convert.ToDateTime(objevent.Event.EndDate.Value.ToString("yyyy-MM-dd h:mm tt"));

                    _iEventService.Insert(objevent.Event);
                    _unitOfWork.SaveChanges();

                    if (objevent.EventDoc1 != null && objevent.EventDoc1.ContentLength > 0 && objevent.EventDoc1.FileName.Substring(objevent.EventDoc1.FileName.Length - 4, 4).ToLower() == ".pdf")
                    {
                        var imagebyte = ConvertsToBytes(objevent.EventDoc1);
                        objbinaryObject.Object = imagebyte;
                        objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.EventDoc;
                        objbinaryObject.Name = objevent.EventDoc1.FileName;
                        objbinaryObject.RefObjectKey = objevent.Event.EventsId;
                        objbinaryObject.Extension = objevent.EventDoc1.ContentType;
                        _iBinaryObjectService.Insert(objbinaryObject);
                        _unitOfWork.SaveChanges();
                    }
                    if (objevent.Logo != null && objevent.Logo.ContentLength > 0)
                    {
                        var imagebyte = ConvertsToBytes(objevent.Logo);
                        objbinaryObject.Object = imagebyte;
                        objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.EventLogo;
                        objbinaryObject.Name = objevent.Logo.FileName;
                        objbinaryObject.RefObjectKey = objevent.Event.EventsId;
                        objbinaryObject.Extension = objevent.Logo.ContentType;
                        _iBinaryObjectService.Insert(objbinaryObject);
                        _unitOfWork.SaveChanges();
                    }
                    EventVM objEventVM = new EventVM();
                    var newEvent = _iEventService.newEvent();
                    objEventVM.Event = newEvent;
                    ViewBag.Success = true;
                    ViewBag.Message = "Event added successfully.";
                    rtn = RedirectToAction("Index");
                    //  trun.Commit();
                }
                else
                {
                    EventVM objEventVM = new EventVM();
                    var newEvent = _iEventService.newEvent();
                    objEventVM.Event = newEvent;
                    ViewBag.Success = false;
                    ViewBag.Message = "Model is not valid.";
                    rtn = View("create", objEventVM);
                    //  trun.Rollback();
                }
            }
            catch (Exception ex)
            {
                EventVM objEventVM = new EventVM();
                var newEvent = _iEventService.newEvent();
                objEventVM.Event = newEvent;
                ViewBag.Success = false;
                ViewBag.Message = ex.Message;
                rtn = View("create", objEventVM);
                //  trun.Rollback();
            }
            // }

            return rtn;
        }
        public int AddBinaryObject(byte[] BinaryObject, string name, string Ext, int TypeId)
        {
            int rtnId = 0;
            string viewPath = string.Empty;
            string setPath = string.Empty;
            BinaryObject objbinaryObject = new BinaryObject();
            objbinaryObject.Name = name;
            objbinaryObject.Object = BinaryObject;
            objbinaryObject.Extension = Ext;
            objbinaryObject.RefObjectTypeId = TypeId;//need to be change.

            viewPath = "/binaryObj/";
            setPath = System.Web.HttpContext.Current.Server.MapPath("~/binaryObj");
            objbinaryObject.ObjectPath = viewPath;//"/binaryObj/" + name + Ext;
            _context.BinaryObjects.Add(objbinaryObject);
            _context.SaveChanges();
            rtnId = objbinaryObject.BinaryObjectsId;
            AddTobinaryObjFolder(setPath + "/" + rtnId.ToString() + name + Ext, BinaryObject);
            return rtnId;
        }

        public bool EditBinaryObject(int? Id, byte[] BinaryObject, string name, string Ext, int TypeId)
        {
            int rtnId = 0;
            string viewPath = string.Empty;
            string setPath = string.Empty;
            BinaryObject objbinaryObject = _context.BinaryObjects.Where(x => x.BinaryObjectsId == Id).FirstOrDefault();

            objbinaryObject.Name = name;
            objbinaryObject.Object = BinaryObject;
            objbinaryObject.Extension = Ext;
            objbinaryObject.RefObjectTypeId = TypeId;//need to be change.

            viewPath = "/binaryObj/" + Id.ToString() + name + Ext;
            setPath = System.Web.HttpContext.Current.Server.MapPath("~/binaryObj");
            objbinaryObject.ObjectPath = "/binaryObj/" + name + Ext;
            _context.Entry(objbinaryObject).State = EntityState.Modified;
            _context.SaveChanges();
            rtnId = objbinaryObject.BinaryObjectsId;
            AddTobinaryObjFolder(setPath + "/" + rtnId.ToString() + name + Ext, BinaryObject);
            return true;
        }

        public void AddTobinaryObjFolder(string pathWithName, byte[] bynaryobject)
        {
            if (!System.IO.File.Exists(pathWithName))
            {
                System.IO.File.WriteAllBytes(pathWithName, bynaryobject);
            }
        }
        public ViewResult DeleteEvent()
        {
            _context.Database.ExecuteSqlCommand("delete Events DBCC CHECKIDENT ('Events', RESEED, 0)");
            _context.Database.ExecuteSqlCommand("delete binaryObjects where ObjectTypeId = 6");
            TempData.Add("status", "Events has been deleted successfully");
            return View();
        }

        public ViewResult SearchEvent(int Type, string PostCode)
        {
            List<Event> lstEvent = _context.Events.Where(x => x.IsVisible == true && x.EventsTypeId == Type && x.PostCode.Trim().Contains(PostCode.Trim())).OrderByDescending(x => x.EventsDate).ToList();
            return View(lstEvent);
        }

        public ActionResult Edit(int Id)
        {
            EventVM objEventVM = new EventVM();
            objEventVM.Event = _iEventService.Find(Id);
            var newEvent = _iEventService.newEvent();
            objEventVM.Event.kvpEventType = newEvent.kvpEventType;
            return View(objEventVM);
        }
       
        [HttpPost]
        public ActionResult Edit(EventVM objevent)
        {
            ActionResult rtn = View();
            BinaryObject objbinaryObject = new HMS.Entities.Models.BinaryObject();
            //using (var trun = _unitOfWork.BeginTransaction()
            //{
            try
            {

                if (ModelState.IsValid)
                {
                    if (objevent.EventDoc1 != null && objevent.EventDoc1.ContentLength > 0 && objevent.EventDoc1.FileName.Substring(objevent.EventDoc1.FileName.Length - 4, 4).ToLower() == ".pdf")
                    {
                      var   objbinaryObject1=   _iBinaryObjectService.GetBinaryObjectById( objevent.Event.EventsId, (int)utility.binaryObjectTypes.EventDoc);
                      if (objbinaryObject1==null) {
                          var imagebyte = ConvertsToBytes(objevent.EventDoc1);
                          objbinaryObject.Object = imagebyte;
                          objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.EventDoc;
                          objbinaryObject.Name = objevent.EventDoc1.FileName;
                          objbinaryObject.RefObjectKey = objevent.Event.EventsId;
                          objbinaryObject.Extension = objevent.EventDoc1.ContentType;
                          _iBinaryObjectService.Insert(objbinaryObject);
                          _unitOfWork.SaveChanges();
                      }
                      else
                      {
                          var imagebyte = ConvertsToBytes(objevent.EventDoc1);
                          objbinaryObject1.Object = imagebyte;
                          //objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.EventDoc;
                          objbinaryObject1.Name = objevent.EventDoc1.FileName;
                          //objbinaryObject.RefObjectKey = objevent.Event.EventsId;
                          objbinaryObject1.Extension = objevent.EventDoc1.ContentType;
                          _iBinaryObjectService.Update(objbinaryObject1);
                          _unitOfWork.SaveChanges();
                      }
                       
                    }
                    if (objevent.Logo != null && objevent.Logo.ContentLength > 0)
                    {
                       var objbinaryObject2=   _iBinaryObjectService.GetBinaryObjectById( objevent.Event.EventsId, (int)utility.binaryObjectTypes.EventLogo);
                       if (objbinaryObject2==null)
                       {
                           var imagebyte = ConvertsToBytes(objevent.Logo);
                           objbinaryObject.Object = imagebyte;
                           objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.EventLogo;
                           objbinaryObject.Name = objevent.Logo.FileName;
                           objbinaryObject.RefObjectKey = objevent.Event.EventsId;
                           objbinaryObject.Extension = objevent.Logo.ContentType;
                           _iBinaryObjectService.Insert(objbinaryObject);
                           _unitOfWork.SaveChanges();
                        }
                       else
                       {
                           var imagebyte = ConvertsToBytes(objevent.Logo);
                           objbinaryObject2.Object = imagebyte;
                           //objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.EventLogo;
                           objbinaryObject2.Name = objevent.Logo.FileName;
                           //objbinaryObject.RefObjectKey = objevent.Event.EventsId;
                           objbinaryObject2.Extension = objevent.Logo.ContentType;
                           _iBinaryObjectService.Update(objbinaryObject2);
                           _unitOfWork.SaveChanges();
                       }
                    }
                    objevent.Event.EventsDate = objevent.Event.EventsDate; ;
                    _iEventService.Update(objevent.Event);
                    _unitOfWork.SaveChanges();
                    EventVM objEventVM = new EventVM();
                    var newEvent = _iEventService.newEvent();
                    objEventVM.Event = newEvent;
                    ViewBag.Success = true;
                    ViewBag.Message = "Event added successfully.";
                    rtn = RedirectToAction("Index");
                    //  trun.Commit();
                }
                else
                {
                    EventVM objEventVM = new EventVM();
                    var newEvent = _iEventService.newEvent();
                    objEventVM.Event = newEvent;
                    ViewBag.Success = false;
                    ViewBag.Message = "Model is not valid.";
                    rtn = View("create", objEventVM);
                    //  trun.Rollback();
                }
            }
            catch (Exception ex)
            {
                EventVM objEventVM = new EventVM();
                var newEvent = _iEventService.newEvent();
                objEventVM.Event = newEvent;
                ViewBag.Success = false;
                ViewBag.Message = ex.Message;
                rtn = View("create", objEventVM);
                //  trun.Rollback();
            }
            return rtn;
        }
    }
}
