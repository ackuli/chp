using HMS.Entities.Models;
using HMS.Service.Models;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using System.IO;
using HMS.Admin.Utility;
namespace HMS.Admin.Controllers
{
    public class PackagesInfoController : Controller
    {
        private readonly IPackagesInfoService _IPackagesInfoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBinaryObjectService _iBinaryObjectService;
        public PackagesInfoController(IPackagesInfoService IPackagesInfoService
            , IUnitOfWork unitOfWork
            , IBinaryObjectService iBinaryObjectService

                        )
        {
            _IPackagesInfoService = IPackagesInfoService;
            _iBinaryObjectService = iBinaryObjectService;
            _unitOfWork = unitOfWork;

        }
        [CustomActionFilterAttribute]
        public ActionResult PackagesInfoList(int? page, string searchItem)
        {
            var currentPageIndex = page.HasValue ? page.Value : 1;
            const int defaultPageSize = 10;
            var ClientId = HMS.Admin.MvcApplication.GolbalSession.gblSession.ClientId;
            var roleid = HMS.Admin.MvcApplication.GolbalSession.gblSession.RoleId;
            IList<PackagesInfo> packageList = new List<PackagesInfo>();
            ViewData["searchItem"] = searchItem;
            if (roleid == "3")
            {//Client
                packageList = (IList<PackagesInfo>)_IPackagesInfoService.GetAllPackagesInfo(ClientId).ToList();
                if (string.IsNullOrWhiteSpace(searchItem))
                {
                    packageList = packageList.ToPagedList(currentPageIndex, defaultPageSize);
                }
                else
                {
                    packageList = packageList.Where(p => p.PackageName.ToString().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, defaultPageSize);
                }
            }
            else if (roleid == "1")//Admin
            {
                packageList = (IList<PackagesInfo>)_IPackagesInfoService.GetAllPackagesInfo().ToList();
                if (string.IsNullOrWhiteSpace(searchItem))
                {
                    packageList = packageList.ToPagedList(currentPageIndex, defaultPageSize);
                }
                else
                {
                    packageList = packageList.Where(p => p.PackageName.ToString().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, defaultPageSize);
                }
            }
            return View(packageList);

        }
        [CustomActionFilterAttribute]
        // GET: ClientInformation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientInformation/Create

        [CustomActionFilterAttribute]
        public ActionResult PackagesInfoCreate()
        {
            var packageInfo = _IPackagesInfoService.newPackagesInfo();
            return View(packageInfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomActionFilterAttribute]
        public ActionResult PackagesInfoCreate([Bind(Include = "PackageId,PackageName,PackagesubscribeId,StatusId,IsFlightDepRetDateExist,DistanceUnitId,Duration,PeoplePerRooms,ClientId , PricePerPerson , PriceTypeId , PackageTypeId ,PackageDisplayTypeId, HotelNameMakka , HotelDistanceMakka , HotelNameMadinah ,HotelClassId, HotelDistanceMadinah , Occupancy ,FlightsDepart ,FlightsReturn ,Remarks ,ShiftingId ,SetBy,LastUpdateDate,PackageDisplayInput")] PackagesInfo PackagesInfo, HttpPostedFileBase file)
        {
            PackagesInfo.SetBy = HMS.Admin.MvcApplication.GolbalSession.gblSession.UserId;
            PackagesInfo.ClientId = HMS.Admin.MvcApplication.GolbalSession.gblSession.ClientId;
            PackagesInfo.LastUpdateDate = DateTime.Now;
            PackagesInfo.PackageCreationdate = DateTime.Now;
            if (HMS.Admin.MvcApplication.GolbalSession.gblSession.RoleId == "1")//Admin
            {
                PackagesInfo.StatusId = 2;
            }
            else
            {
                PackagesInfo.StatusId = 1;
            }

            PackagesInfo.PriceTypeId = 1;
            if (ModelState.IsValid)
            {
                var objbinaryObject = new HMS.Entities.Models.BinaryObject();
                if (file != null)
                {
                    objbinaryObject = _iBinaryObjectService.GetBinaryObjectById(PackagesInfo.PackageId, 10);
                    if (PackagesInfo.PackageDisplayTypeId == 3)//Package Lleaflet
                    {
                        if (objbinaryObject == null)
                        {
                            objbinaryObject = new HMS.Entities.Models.BinaryObject(); ;
                            var imagebyte = ConvertsToBytes(file);
                            objbinaryObject.RefObjectKey = PackagesInfo.PackageId;
                            objbinaryObject.Object = imagebyte;
                            objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.PackageLeaflet;
                            objbinaryObject.Name = file.FileName;
                            objbinaryObject.Extension = file.ContentType;
                            _iBinaryObjectService.Insert(objbinaryObject);
                        }
                        else
                        {

                            var imagebyte = ConvertsToBytes(file);
                            objbinaryObject.Object = imagebyte;
                            objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.News;
                            objbinaryObject.Name = file.FileName;
                            objbinaryObject.Extension = file.ContentType;
                            _iBinaryObjectService.Update(objbinaryObject);
                        }

                        _unitOfWork.SaveChanges();
                    }


                }
                _IPackagesInfoService.Insert(PackagesInfo);
                _unitOfWork.SaveChanges();
                return RedirectToAction("PackagesInfoList");
            }
            return RedirectToAction("PackagesInfoCreate");
        }
        public byte[] ConvertsToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        [CustomActionFilterAttribute]
        public ActionResult PackagesInfoDetails(int id)
        {
            var packageInfo = _IPackagesInfoService.GetPackagesInfoById(id);
            packageInfo.StatusId = 2;
            _IPackagesInfoService.Update(packageInfo);
            _unitOfWork.SaveChanges();
            return RedirectToAction("PackagesInfoList");
        }
        [CustomActionFilterAttribute]
        public ActionResult ApprovedPackagesInfo(int id, int StatusId)
        {
            var packageInfo = _IPackagesInfoService.GetPackagesInfoById(id);
            packageInfo.StatusId = StatusId;
            _IPackagesInfoService.Update(packageInfo);
            _unitOfWork.SaveChanges();
            return RedirectToAction("PackagesInfoList");
        }
        // GET: ClientInformation/Edit/5

        //[ValidateAntiForgeryToken]
        [CustomActionFilterAttribute]
        public ActionResult EditPackagesInfo(int id)
        {
            var packageInfo = _IPackagesInfoService.GetPackagesInfoById(id);
            var packageInfonew = _IPackagesInfoService.newPackagesInfo();
            packageInfo.kvpCurrencyType = packageInfonew.kvpCurrencyType;
            packageInfo.kvpDuration = packageInfonew.kvpDuration;
            packageInfo.kvpPackagetype = packageInfonew.kvpPackagetype;
            packageInfo.kvpPeoplePerRoom = packageInfonew.kvpPeoplePerRoom;
            packageInfo.kvplistHotelClass = packageInfonew.kvplistHotelClass;
            packageInfo.kvplistShifting = packageInfonew.kvplistShifting;
            packageInfo.kvpPackagesubscribe = packageInfonew.kvpPackagesubscribe;
            packageInfo.kvpPackageDisplayType = packageInfonew.kvpPackageDisplayType;
            packageInfo.kvpDistanceUnit = packageInfonew.kvpDistanceUnit;
            return View(packageInfo);
        }

        // POST: ClientInformation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPackagesInfo([Bind(Include = "PackageId,PackagesubscribeId,HotelClassId,PackageName,StatusId,IsFlightDepRetDateExist,DistanceUnitId,Duration , ClientId , PricePerPerson , PriceTypeId , PackageTypeId ,PackageDisplayTypeId, HotelNameMakka , HotelDistanceMakka , HotelNameMadinah , HotelDistanceMadinah , PeoplePerRooms ,FlightsDepart ,FlightsReturn ,Remarks ,ShiftingId ,SetBy,LastUpdateDate,PackageDisplayInput,PackageCreationdate")] PackagesInfo PackagesInfo, HttpPostedFileBase file)
        {
            PackagesInfo.SetBy = HMS.Admin.MvcApplication.GolbalSession.gblSession.UserId;
            PackagesInfo.LastUpdateDate = DateTime.Now;
            
            PackagesInfo.PriceTypeId = 1;
            if (ModelState.IsValid)
            {
                var objbinaryObject = new HMS.Entities.Models.BinaryObject();
                if (file != null)
                {
                    objbinaryObject = _iBinaryObjectService.GetBinaryObjectById(PackagesInfo.PackageId, 10);
                    if (objbinaryObject == null)
                    {
                        objbinaryObject = new HMS.Entities.Models.BinaryObject(); ;
                        var imagebyte = ConvertsToBytes(file);
                        objbinaryObject.RefObjectKey = PackagesInfo.PackageId;
                        objbinaryObject.Object = imagebyte;
                        objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.PackageLeaflet;
                        objbinaryObject.Name = file.FileName;
                        objbinaryObject.Extension = file.ContentType;
                        _iBinaryObjectService.Insert(objbinaryObject);
                    }
                    else
                    {

                        var imagebyte = ConvertsToBytes(file);
                        objbinaryObject.Object = imagebyte;
                        objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.News;
                        objbinaryObject.Name = file.FileName;
                        objbinaryObject.Extension = file.ContentType;
                        _iBinaryObjectService.Update(objbinaryObject);
                    }

                    _unitOfWork.SaveChanges();


                }
                _IPackagesInfoService.Update(PackagesInfo);
                _unitOfWork.SaveChanges();
                return RedirectToAction("PackagesInfoList");
            }
            return RedirectToAction("PackagesInfoCreate");
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
