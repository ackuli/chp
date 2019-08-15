using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Models;
using MvcPaging;

namespace HMS.Controllers
{
    public class SubscribeController : Controller
    {
        //
        // GET: /Subscribe/
        private HMSContext _context = new HMSContext();
        private const int PAGE_SIZE = 6;
        public ActionResult Index(string SearchText, int? page)
        {
            ViewData["SearchText"] = SearchText;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<HMS.Models.Subscribe> lstSubscribe = _context.Subscribes.OrderByDescending(x => x.SetDate).ToList();

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                lstSubscribe = lstSubscribe.ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            else
            {
                lstSubscribe = lstSubscribe.Where(p => p.Email.ToLower().Contains(SearchText.ToLower())).ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            return View(lstSubscribe);


            return View();
        }

    }
}
