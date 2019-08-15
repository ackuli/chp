using HMS.Entities.ViewModels;
using HMS.Service.Models;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using HMS.Entities.Models;
namespace HMS.Controllers
{
    public class PackagesInfoController : Controller
    {
        private readonly IPackagesInfoService _IPackagesInfoService;
        private readonly IUnitOfWork _unitOfWork;
        public PackagesInfoController(IPackagesInfoService IPackagesInfoService, IUnitOfWork unitOfWork)
        {   _IPackagesInfoService = IPackagesInfoService;
            _unitOfWork = unitOfWork;
        }      
        public ActionResult PackagestUmrahList(HomePageViewModel SearchCriteria, int? page, string searchItem)
        {
            SearchCriteria = (HomePageViewModel)Session["SearchCriteria"];
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int PAGE_SIZE = 6;
            IList<HMS.Entities.Models.PackagesInfo> lstPackagesInfo = _IPackagesInfoService.GetPackagesInfoBySearchCriteria(SearchCriteria).OrderBy(x => x.PricePerPerson).ToList();
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                lstPackagesInfo = lstPackagesInfo.ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            else
            {
                lstPackagesInfo = lstPackagesInfo.Where(p => p.PackageName.ToLower().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            return View(lstPackagesInfo);
        }
       
        public ActionResult PackagesInfoDetails(int id)
        {
            var packageInfo = _IPackagesInfoService.GetPackagesInfoById(id);
            return View(packageInfo);
        }
        public ActionResult PackagesInfoLleaflet(int id)
        {
            var packageInfo = new PackagesInfo();
            packageInfo.PackageId = id;
            return View(packageInfo);
        }
        public ActionResult PackagesInfoList(HomePageViewModel SearchCriteria, int? page, string searchItem)
        {
            var SearchCriteria1 = (HomePageViewModel)Session["SearchCriteria"];
            if (page == null)
            {
                if (SearchCriteria1!=null)
                {
                    Session["SearchCriteria"] = SearchCriteria1;
                }
                else
                {
                    Session["SearchCriteria"] = SearchCriteria;
                }
                ViewData["searchItem"] = searchItem;
                TempData["SearchCriteria"] = SearchCriteria;
            }
            if (SearchCriteria.IsHajjUmrah == "2")
            {
                Session["SearchCriteria"] = SearchCriteria;
                TempData["SearchCriteria"] = SearchCriteria;
                return RedirectToAction("PackagestUmrahList", new { });
            }
            SearchCriteria = (HomePageViewModel)Session["SearchCriteria"];
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int PAGE_SIZE =6;
            IList<HMS.Entities.Models.PackagesInfo> lstPackagesInfo = _IPackagesInfoService.GetPackagesInfoBySearchCriteria(SearchCriteria).OrderBy(x=>x.PricePerPerson).ToList();
            if (string.IsNullOrWhiteSpace(searchItem))
            {
                lstPackagesInfo = lstPackagesInfo.ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            else
            {
                lstPackagesInfo = lstPackagesInfo.Where(p => p.PackageName.ToLower().Contains(searchItem.ToLower())).ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            return View(lstPackagesInfo);
        }
    }
}
