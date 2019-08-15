using HMS.Entities.Models;
using HMS.Service.Models;
using HMS.Admin.Utility;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using System.IO;
namespace HMS.Admin.Controllers
{
    public class ScholareController : Controller
    {
        private readonly IScholareService _IScholareService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBinaryObjectService _iBinaryObjectService;

        public ScholareController(IScholareService IScholareService
            , IUnitOfWork unitOfWork
            , IBinaryObjectService iBinaryObjectService

                        )
        {
            _IScholareService = IScholareService;
            _iBinaryObjectService = iBinaryObjectService;
            _unitOfWork = unitOfWork;

        }
        [CustomActionFilterAttribute]
        public ActionResult ScholareList(int? page, string searchItem)
        {
            var currentPageIndex = page.HasValue ? page.Value : 1;
            const int defaultPageSize = 10;
            IList<Scholare> schInfo = new List<Scholare>();
            ViewData["searchItem"] = searchItem;
                schInfo = (IList<Scholare>)_IScholareService.GetAllScholare().ToList();
                if (string.IsNullOrWhiteSpace(searchItem))
                {
                    schInfo = schInfo.ToPagedList(currentPageIndex, defaultPageSize);
                }
                else
                {
                    schInfo = schInfo.Where(p => p.ScholarName.ToString().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, defaultPageSize);
                }
            return View(schInfo);

        }

        [CustomActionFilterAttribute]
        public ActionResult Details(int id)
        {
            return View();
        }

        [CustomActionFilterAttribute]
        public ActionResult ScholareCreate()
        {
            Scholare sh = new Scholare();
            sh.IsActive = true;
            return View(sh);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [CustomActionFilterAttribute]
        public ActionResult ScholareCreate([Bind(Include = "ScholarId,ScholarName,Scholarbiography,IsActive")] Scholare Scholare, HttpPostedFileBase file)
        {
            Scholare.Logdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var objbinaryObject = new HMS.Entities.Models.BinaryObject();
                _IScholareService.Insert(Scholare);
                _unitOfWork.SaveChanges();
                if (file != null)
                {
                    objbinaryObject = _iBinaryObjectService.GetBinaryObjectById(Scholare.ScholarId, 11);
                        if (objbinaryObject == null)
                        {
                            objbinaryObject = new HMS.Entities.Models.BinaryObject(); ;
                            var imagebyte = ConvertsToBytes(file);
                            objbinaryObject.RefObjectKey = Scholare.ScholarId;
                            objbinaryObject.Object = imagebyte;
                            objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.Scholare;
                            objbinaryObject.Name = file.FileName;
                            objbinaryObject.Extension = file.ContentType;
                            _iBinaryObjectService.Insert(objbinaryObject);
                        }
                        else
                        {

                            var imagebyte = ConvertsToBytes(file);
                            objbinaryObject.Object = imagebyte;
                            objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.Scholare;
                            objbinaryObject.Name = file.FileName;
                            objbinaryObject.Extension = file.ContentType;
                            _iBinaryObjectService.Update(objbinaryObject);
                        }

                        _unitOfWork.SaveChanges();
                }
                return RedirectToAction("ScholareList");
            }
            return RedirectToAction("ScholareCreate");
        }
        
        public byte[] ConvertsToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        //[ValidateAntiForgeryToken]
        [CustomActionFilterAttribute]
        public ActionResult EditScholare(int id)
        {
            var schInfo = _IScholareService.GetScholareById(id);
            return View(schInfo);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditScholare([Bind(Include = "ScholarId,ScholarName,Scholarbiography,IsActive")] Scholare Scholare, HttpPostedFileBase file)
        {
            Scholare.Logdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var objbinaryObject = new HMS.Entities.Models.BinaryObject();
                if (file != null)
                {
                    objbinaryObject = _iBinaryObjectService.GetBinaryObjectById(Scholare.ScholarId, 11);
                    if (objbinaryObject == null)
                    {
                        objbinaryObject = new HMS.Entities.Models.BinaryObject(); ;
                        var imagebyte = ConvertsToBytes(file);
                        objbinaryObject.RefObjectKey = Scholare.ScholarId;
                        objbinaryObject.Object = imagebyte;
                        objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.Scholare;
                        objbinaryObject.Name = file.FileName;
                        objbinaryObject.Extension = file.ContentType;
                        _iBinaryObjectService.Insert(objbinaryObject);
                    }
                    else
                    {

                        var imagebyte = ConvertsToBytes(file);
                        objbinaryObject.Object = imagebyte;
                        objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.Scholare;
                        objbinaryObject.Name = file.FileName;
                        objbinaryObject.Extension = file.ContentType;
                        _iBinaryObjectService.Update(objbinaryObject);
                    }

                    _unitOfWork.SaveChanges();

                }
                _IScholareService.Update(Scholare);
                _unitOfWork.SaveChanges();
                return RedirectToAction("ScholareList");
            }
            return RedirectToAction("ScholareCreate");
        }

        public ActionResult Delete(int id)
        {
            var schInfo = _IScholareService.GetScholareById(id);
            schInfo.IsActive = false;
            _IScholareService.Update(schInfo);
            _unitOfWork.SaveChanges();
            return RedirectToAction("ScholareList");
        }

        //[CustomActionFilterAttribute]
        //public ActionResult ScholareDetails(int id)
        //{
        //    var packageInfo = _IScholareService.GetScholareById(id);
        //    packageInfo.StatusId = 2;
        //    _IScholareService.Update(packageInfo);
        //    _unitOfWork.SaveChanges();
        //    return RedirectToAction("ScholareList");
        //}
        //[CustomActionFilterAttribute]
        //public ActionResult ApprovedScholare(int id)
        //{
        //    var packageInfo = _IScholareService.GetScholareById(id);
        //    packageInfo.StatusId = 2;
        //    _IScholareService.Update(packageInfo);
        //    _unitOfWork.SaveChanges();
        //    return RedirectToAction("ScholareList");
        //}
        //// GET: ClientInformation/Edit/5

        ////[ValidateAntiForgeryToken]
        //[CustomActionFilterAttribute]
        //public ActionResult EditScholare(int id)
        //{
        //    var packageInfo = _IScholareService.GetScholareById(id);
        //    var packageInfonew = _IScholareService.newScholare();
        //    packageInfo.kvpCurrencyType = packageInfonew.kvpCurrencyType;
        //    packageInfo.kvpDuration = packageInfonew.kvpDuration;
        //    packageInfo.kvpPackagetype = packageInfonew.kvpPackagetype;
        //    packageInfo.kvpPeoplePerRoom = packageInfonew.kvpPeoplePerRoom;
        //    packageInfo.kvplistHotelClass = packageInfonew.kvplistHotelClass;
        //    packageInfo.kvplistShifting = packageInfonew.kvplistShifting;
        //    packageInfo.kvpPackagesubscribe = packageInfonew.kvpPackagesubscribe;
        //    packageInfo.kvpPackageDisplayType = packageInfonew.kvpPackageDisplayType;
        //    return View(packageInfo);
        //}

        //// POST: ClientInformation/Edit/5
        

        //// GET: ClientInformation/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ClientInformation/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
