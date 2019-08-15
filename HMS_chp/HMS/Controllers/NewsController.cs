using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using System.IO;
using Repository.Pattern.UnitOfWork;
using HMS.Service.Models;
using MvcPaging;
using HMS.Entities.Models;
namespace HMS.Controllers
{
    public class NewsController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;      
        private readonly INewssService _iNewssService;
        private readonly IBinaryObjectService _iBinaryObjectService;
        public NewsController(IUnitOfWork unitOfWork,INewssService iNewssService,IBinaryObjectService iBinaryObjectService)
        {           
            _unitOfWork = unitOfWork;
            _iBinaryObjectService = iBinaryObjectService;
            _iNewssService = iNewssService;

        }
        public ActionResult Index(int? page, string searchItem)
        {
            
            const int defaultPageSize = 5;
            ViewData["searchItem"] = searchItem;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<HMS.Entities.Models.News> lstNews = _iNewssService.GetAllNews().OrderByDescending(x => x.LastUpdateTime).ToList();
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                lstNews = lstNews.ToPagedList(currentPageIndex, defaultPageSize);
            }
            else
            {
                lstNews = lstNews.Where(p => p.NewsTitle.ToLower().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, defaultPageSize);
            }
            return View(lstNews);
           
        }
        public ActionResult LatestNewsList(int? page)
        {
            int PAGE_SIZE = 5;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            var objNewsList = _iNewssService.GetActiveNews(true);
            objNewsList = (IPagedList<News>)objNewsList.ToList().ToPagedList(currentPageIndex, PAGE_SIZE);            
            return View(objNewsList);
          
        }
        public ActionResult ArchiveNewsList(int? page)
        {
            int PAGE_SIZE = 5;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            var objNewsList = _iNewssService.GetArchiveNews(true);
            objNewsList = (IPagedList<News>)objNewsList.ToList().ToPagedList(currentPageIndex, PAGE_SIZE);
            return View(objNewsList);
        }
        public ActionResult Create()
        {
            return View();
        }

        public byte[] ConvertsToBytes( HttpPostedFileBase image )
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(News news, HttpPostedFileBase file)
        {
            BinaryObject objbinaryObject = new HMS.Entities.Models.BinaryObject();                      
             try
             {
               
                 if (ModelState.IsValid)
                 {
                     _iNewssService.Insert(news);
                     _unitOfWork.SaveChanges();
                 }
                 if (file != null)
                 {
                     var imagebyte = ConvertsToBytes(file);
                     objbinaryObject.Object = imagebyte;
                     objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.News;
                     objbinaryObject.Name = file.FileName;
                     objbinaryObject.RefObjectKey = news.NewsId;
                     objbinaryObject.Extension = file.ContentType;
                     _iBinaryObjectService.Insert(objbinaryObject);
                     _unitOfWork.SaveChanges();

                 }
                 return RedirectToAction("Index");
             }
            catch(Exception mgs){
              //  TempData.Add("danger", "Exception Occured");
                return RedirectToAction("Index");
                //var newsList = _context.News.ToList();
                //TempData.Add("danger", "Exception Occured");
                //return View("Index", newsList);
            }
            
        }
        public ActionResult Edit(int Id)
        {
            var objNews = _iNewssService.GetNewsById(Id);
         //   objNews.
            return View(objNews);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(News news, HttpPostedFileBase file)
        {
            BinaryObject objbinaryObject = new HMS.Entities.Models.BinaryObject();
            if (ModelState.IsValid)
            {
                //using (var tran = .Database.BeginTransaction())
                //{
                    try
                    {
                        if (file != null)
                        {
                           objbinaryObject= _iBinaryObjectService.GetBinaryObjectById(news.NewsId, 7);
                           if (objbinaryObject==null) {
                               objbinaryObject = new HMS.Entities.Models.BinaryObject(); ;
                               var imagebyte = ConvertsToBytes(file);
                               objbinaryObject.RefObjectKey = news.NewsId;
                               // objbinaryObject.BinaryObjectsId=news.B
                               objbinaryObject.Object = imagebyte;
                               objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.News;
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
                        _iNewssService.Update(news);
                        _unitOfWork.SaveChanges();
                     //   TempData.Add("success", "News updated successfully");
                        return RedirectToAction("Index");
                       // return View("Index", _context.News.ToList());
                    }
                    catch (Exception ex)
                    {
                      //  tran.Rollback();
                      //  TempData.Add("error", ex.Message);
                        RedirectToAction("Edit");
                    }
               // }
            }
            else
            {
                RedirectToAction("Edit");
            }
            return View("Index");



        }
        public ActionResult Details(int Id)
        {
            return View(_iNewssService.Find(Id));
        }

        public ActionResult DetailsForClient(int Id)
        {
            return View(_iNewssService.Find(Id));
        }
        public ActionResult Delete(int Id)
        {
            var news = _iNewssService.Find(Id);
            if (news != null)
            {
               // experience.Setdate = DateTime.Now;
               // experience.IsActive = false;
                //using (var tran = _context.Database.BeginTransaction())
                //{
                //    try
                //    {
                //        _context.Entry(news).State = EntityState.Modified;
                //        _context.SaveChanges();
                //        TempData.Add("success", "News updated successfully");
                //        tran.Commit();
                //    }
                //    catch (Exception ex)
                //    {
                //        tran.Rollback();
                //        TempData.Add("error", ex.Message);
                //        RedirectToAction("Edit");
                //    }
                //}
            }
            else
            {
                RedirectToAction("Index");
            }
            return View("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
