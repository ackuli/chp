using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Models;
using HMS.Utility;
using HMS.ViewModels;

namespace HMS.Controllers
{
    public class AdvertiseoldController : Controller
    {
        //
        // GET: /Advertise/
        HMSContext _Context = new Models.HMSContext();
        public ActionResult Index()
        {
            List<Advertise> lstAdvertise = _Context.Advertises.ToList();
            return View(lstAdvertise);
        }
        public ActionResult create()
        {
            Advertise objAdvertise = new Advertise();

            var AdvertiseTypeList = new List<KeyValuePair<int, string>>();
            _Context.AdvertiseTypes.ToList().ForEach(delegate(AdvertiseType item)
            {
                AdvertiseTypeList.Add(new KeyValuePair<int, string>(item.Id, item.Name));
            });


            var AdvertisePositionlst = new List<KeyValuePair<int, string>>();
            _Context.AdvertisePositions.ToList().ForEach(delegate(AdvertisePosition item)
            {
                AdvertisePositionlst.Add(new KeyValuePair<int, string>(item.Id, item.Name));
            });

            objAdvertise.lstAdvertisePosition = AdvertisePositionlst;
            objAdvertise.lstAdvertiseType = AdvertiseTypeList;

            AdvertiseVM objAdvertiseVM = new AdvertiseVM();
            objAdvertiseVM.Advertise = objAdvertise;

            return View(objAdvertiseVM);
        }
        [HttpPost]
        public ActionResult create(AdvertiseVM objAdvertise)
        {
            ActionResult rtn = View();
            try
            {
                using (var trun = _Context.Database.BeginTransaction())
                {
                    if (objAdvertise.AddPicture != null && objAdvertise.AddPicture.ContentLength > 0)
                    {
                        int length = objAdvertise.AddPicture.ContentLength;
                        var myData = new byte[length];
                        objAdvertise.AddPicture.InputStream.Read(myData, 0, length);

                        int BinobjectId = AddBinaryObject(myData, objAdvertise.Advertise.Name,
                                                          objAdvertise.AddPicture.ContentType);
                    }
                    objAdvertise.Advertise.SetBy = Session["UserId"].ToString();
                    objAdvertise.Advertise.SetDate = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        _Context.Advertises.Add(objAdvertise.Advertise);
                        _Context.SaveChanges();
                        TempData.Add("success", "Member has been added successfully");
                        rtn = RedirectToAction("Index");
                    }
                }


            }
            catch (Exception ex)
            {
                TempData.Add("error", ex.InnerException.InnerException.Message);
                rtn = RedirectToAction("Create");
            }


            return rtn;
        }

        public ActionResult Edit(int Id)
        {
            Advertise objAdvertise = new Advertise();
            objAdvertise = _Context.Advertises.Where(x => x.Id == Id).FirstOrDefault();
            var AdvertiseTypeList = new List<KeyValuePair<int, string>>();
            _Context.AdvertiseTypes.ToList().ForEach(delegate(AdvertiseType item)
            {
                AdvertiseTypeList.Add(new KeyValuePair<int, string>(item.Id, item.Name));
            });


            var AdvertisePositionlst = new List<KeyValuePair<int, string>>();
            _Context.AdvertisePositions.ToList().ForEach(delegate(AdvertisePosition item)
            {
                AdvertisePositionlst.Add(new KeyValuePair<int, string>(item.Id, item.Name));
            });

            objAdvertise.lstAdvertisePosition = AdvertisePositionlst;
            objAdvertise.lstAdvertiseType = AdvertiseTypeList;

            AdvertiseVM objAdvertiseVM = new AdvertiseVM();
            objAdvertiseVM.Advertise = objAdvertise;

            return View(objAdvertiseVM);
        }
        [HttpPost]
        public ActionResult Edit(AdvertiseVM objAdvertise)
        {
            try
            {
                if (objAdvertise.AddPicture != null && objAdvertise.AddPicture.ContentLength > 0)
                {
                    int length = objAdvertise.AddPicture.ContentLength;
                    var myData = new byte[length];
                    objAdvertise.AddPicture.InputStream.Read(myData, 0, length);
                    //objAdvertise.Advertise.Pictute = myData;
                }
                else
                {
                    byte[] ExistingPic = _Context.Advertises.Where(x => x.Id == objAdvertise.Advertise.Id).FirstOrDefault().Fk_BinaryObjectId.Object;
                    //objAdvertise.Advertise.Pictute = ExistingPic;
                }
                objAdvertise.Advertise.SetBy = Session["UserId"].ToString();
                objAdvertise.Advertise.SetDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    _Context.Advertises.Add(objAdvertise.Advertise);
                    _Context.SaveChanges();
                    TempData.Add("success", "Member has been updated successfully");
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData.Add("error", ex.InnerException.InnerException.Message);
                return RedirectToAction("Create");
            }

            return View("Index");
        }

        public ViewResult SetAdvertise()
        {
            try
            {

                HMS.Entities.Models.HMSContext  _Context = new HMS.Entities.Models.HMSContext();
                List<HMS.Entities.Models.Advertis> lstAddToShow =
                _Context.Advertises.Where(
                    x => x.IsActive == true
                        //&& x.Fk_AdvertisePosition.PageName == "Home Page"
                        && DateTime.Now > x.StartDate
                        && DateTime.Now < x.EndDate
                        && x.IsDefault == false
                        ).ToList();

                var objAdverticeProcessing = new AdverticeProcessing();
                objAdverticeProcessing.setAdverticeImage(lstAddToShow);
                objAdverticeProcessing.AppImage();
                TempData.Add("Status", "Advertice set successfully");
            }
            catch (Exception ex)
            {
                TempData.Add("error", ex.Message);
            }
            return View();
        }






        public int AddBinaryObject(byte[] BinaryObject, string name, string Ext)
        {
            binaryObject objbinaryObject = new binaryObject();
            objbinaryObject.Name = name;
            objbinaryObject.Object = BinaryObject;
            objbinaryObject.ObjectTypeId = 2;//need to be change.
            //objbinaryObject.Path = @"D:\HajjManagementProject\HMS\HMS\HMS\Content\images\" +name + "\\" + Ext;
            objbinaryObject.Path = System.Web.HttpContext.Current.Server.MapPath("binaryObj"); //name + "\\" + Ext; //@"D:\HajjManagementProject\HMS\HMS\HMS\Content\images\" +
            _Context.binaryObjects.Add(objbinaryObject);
            _Context.SaveChanges();
            return objbinaryObject.Id;



        }



    }
}
