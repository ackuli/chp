using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Entities.Models;
using HMS.Utility;
using HMS.Entities.ViewModels;
using MvcPaging;
using HMS.Service.ViewModels;
using Repository.Pattern.UnitOfWork;


namespace HMS.Controllers
{
    public class newsAndEventsController : Controller
    {
        //
        // GET: /newsAndEvents/

        private HMS.Entities.Models.HMSContext _context = new HMS.Entities.Models.HMSContext();

        private readonly IUnitOfWork _unitOfWork;
        private readonly InewsEventVMService _inewsEventVMService;
        public newsAndEventsController(IUnitOfWork unitOfWork, InewsEventVMService inewsEventVMService)
        {

            _inewsEventVMService = inewsEventVMService;
            _unitOfWork = unitOfWork;

        }
        // GET: /Events/
        private const int PAGE_SIZE = 3;
        [MetaKeywords("hajj,hajj 2014,hajj seminar 2014,hajj packages,hajj and umrah,hajj tours,hajj 2015,hajj facts,hajj pilgrimage,hajj 2014 packages uk,hajj guide,hajj packages 2015")]
        [MetaDescription("Coming Soon, the most comprehensive hajj and umrah website that will change the way people search and book hajj and umrah trips")]
        public ActionResult Index(int? EventsTypeId, string PostCode)
        {
            var objEvent = new Event();
            //var objNews = new News();          
            //int currentPageIndex = page.HasValue ? page.Value : 1;
            var objNewsEventVm = _inewsEventVMService.GetNewsAndEventsInfo();
            
            if (EventsTypeId != null && PostCode!=null)
            {
                if (EventsTypeId!=null)
                {
                    objNewsEventVm.EventsList = objNewsEventVm.EventsList.Where((p => p.EventsTypeId == EventsTypeId)).OrderByDescending(x=>x.EventsDate.Day);
                }
                if (!string.IsNullOrEmpty(PostCode))
                {
                    objNewsEventVm.EventsList = objNewsEventVm.EventsList.Where((p => p.PostCode.ToLower().Contains(PostCode.ToLower()))).OrderByDescending(x => x.EventsDate.Day);
                }
               //||p.PostCode.ToLower().Contains(PostCode.ToLower())));
            }
          
            //objNewsEventVm.LstEvents = (IPagedList<Event>)objNewsEventVm.EventsList;
            //objNewsEventVm.LstNews = (IPagedList<News>)objNewsEventVm.LstNewses.OrderBy(x=>x.SourceDate).ToPagedList(currentPageIndex, PAGE_SIZE);
            //objNewsEventVm.LstArchiveNewsPaging = (IPagedList<News>)objNewsEventVm.LstArchiveNews.OrderBy(x => x.SourceDate).ToPagedList(currentPageIndex, PAGE_SIZE);
            var objNewsEventVmnew = _inewsEventVMService.newnewsEventVM();
            objNewsEventVm.EventTypeList = objNewsEventVmnew.EventTypeList;
            objNewsEventVm.Events = objEvent;
            return View(objNewsEventVm);
        }

    }
}
