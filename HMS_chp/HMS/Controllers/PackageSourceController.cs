using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Models;
using MvcPaging;

namespace HMS.Controllers
{
    public class PackageSourceController : Controller
    {
        //
        // GET: /PackageSource/
        HMSContext _context = new Models.HMSContext();
        private const int PAGE_SIZE = 5;

        public ActionResult Index(string searchinfo, int? page)
        {
            ViewData["searchinfo"] = searchinfo;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<HMS.Models.PackageSource> lstPackageSource = _context.PackageSources.ToList();

            if (string.IsNullOrWhiteSpace(searchinfo))
            {
                lstPackageSource = lstPackageSource.ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            else
            {
                lstPackageSource = lstPackageSource.Where(p => p.Name.ToLower().Contains(searchinfo.ToLower())).ToPagedList(currentPageIndex, PAGE_SIZE);
            }

            return View(lstPackageSource);
        }

    }
}
