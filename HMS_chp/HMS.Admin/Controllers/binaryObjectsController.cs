using HMS.Entities.Models;
using HMS.Service.Models;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace HMS.Admin.Controllers
{
    public class binaryObjectsController : Controller
    {

        private readonly IBinaryObjectService _ibinaryObjectService;
        private readonly IUnitOfWork _unitOfWork;
        public binaryObjectsController(
            IBinaryObjectService ibinaryObjectService
            , IUnitOfWork unitOfWork
            )
        {

            _ibinaryObjectService = ibinaryObjectService;
            _unitOfWork = unitOfWork;

        }
        public ActionResult Index()
        {
            return View();
        }
        public int AddBinaryObject(byte[] BinaryObject, string name, string Ext)
        {

            BinaryObject objbinaryObject = new BinaryObject();
            //objbinaryObject.Name = name;
            //objbinaryObject.Object = BinaryObject;
            //objbinaryObject.RefObjectTypeId = 2;//need to be change.
            //objbinaryObject.ObjectPath = @"D:\HajjManagementProject\HMS\HMS\HMS\Content\images\" +
            //                       name + "\\" + Ext;

            //_ibinaryObjectService. (objbinaryObject);
            //_Context.SaveChanges();
            return objbinaryObject.RefObjectTypeId;



        }
        [HttpGet]
        public ActionResult ContentDownload(int RefObjectKey, int objectTypeId)
        {

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var binaryObject = _ibinaryObjectService.GetBinaryObjectById(RefObjectKey, objectTypeId);
            if (binaryObject != null && binaryObject.Object != null)
            {
                var stream = new MemoryStream(binaryObject.Object);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType =
                    new MediaTypeHeaderValue(binaryObject.Extension);
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = binaryObject.FileName
                };
                return File(binaryObject.Object.ToArray(), result.Content.Headers.ContentType.ToString(), binaryObject.FileName);
            }
            else
            {
                result = new HttpResponseMessage(HttpStatusCode.NotFound);

                BinaryObject binaryObject1 = new BinaryObject();
                return File(binaryObject1.Object = binaryObject1.Object == null ? new byte[] { } : binaryObject1.Object, "Pdf");
            }

        }


        public ViewResult SetBinaryObject()
        {
            //List<BinaryObject> lstbinaryObject =
            //    _Context.binaryObjects.Where(
            //        x => x.ObjectTypeId == 4
            //            ).ToList();

            //var objAdverticeProcessing = new AdverticeProcessing();
            //objAdverticeProcessing.AppImage();
            TempData.Add("Status", "Binary Object set successfully");
            return View();
        }
        public ActionResult GetBinaryObject(int BinaryObjectsId, int RefObjectKey, int objectTypeId)
        {

            var binaryObject = _ibinaryObjectService.GetBinaryObject(BinaryObjectsId, RefObjectKey, objectTypeId);
            if (binaryObject == null)
            {
                binaryObject = new BinaryObject();
            }
            return File(binaryObject.Object = binaryObject.Object == null ? new byte[] { } : binaryObject.Object, "image/jpg");
        }
        public ActionResult GetBinaryObjectById(int id, int objectTypeId)
        {

            var binaryObject = _ibinaryObjectService.GetBinaryObjectById(id, objectTypeId);
            if (binaryObject == null)
            {
                binaryObject = new BinaryObject();
            }
            return File(binaryObject.Object = binaryObject.Object == null ? new byte[] { } : binaryObject.Object, "image/jpg");
        }
        public ActionResult GetPDFBinaryObjectById(int id, int objectTypeId)
        {

            var binaryObject = _ibinaryObjectService.GetBinaryObjectById(id, objectTypeId);
            if (binaryObject == null)
            {
                binaryObject = new BinaryObject();
            }
            return File(binaryObject.Object = binaryObject.Object == null ? new byte[] { } : binaryObject.Object, "application/pdf");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
        //public ActionResult GetImage(int id, string refCode, bool isThumbnail = false)
        //{

        //    RefCode refCodes = (RefCode)0;
        //    Enum.TryParse(refCode, true, out refCodes);

        //    var img = _imageService.GetImageByRefTypeIdAndRefPrimaryKey((int)refCodes, id).FirstOrDefault();

        //    if (img != null && img.ImageBinaryData != null)
        //    {
        //        if (isThumbnail == true)
        //        {
        //            Stream stream = new MemoryStream(img.ImageBinaryData);
        //            var imageResize = new ImageResize();
        //            var thumbImg = ImageToByte(imageResize.GetBitmap(stream, 100, 100, 50));
        //            return File(thumbImg, "image/jpg");

        //        }
        //        else
        //        {
        //            return File(img.ImageBinaryData, "image/jpg");
        //        }

        //    }
        //    else
        //    {
        //        pnsms.Entities.Models.Image image = new pnsms.Entities.Models.Image();
        //        img = image;
        //        return File(img.ImageBinaryData = img.ImageBinaryData == null ? new byte[] { } : img.ImageBinaryData, "image/jpg");
        //    }


        //}

        ///// <summary>
        ///// Images to byte.
        ///// </summary>
        ///// <param name="img">The img.</param>
        ///// <returns></returns>
        //public static byte[] ImageToByte(System.Drawing.Image img)
        //{
        //    ImageConverter converter = new ImageConverter();
        //    return (byte[])converter.ConvertTo(img, typeof(byte[]));
        //}
    }
}
