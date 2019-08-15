using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Models;
using System.Data;
using HMS.utility;
using HMS.ViewModels;
using HtmlAgilityPack;
using MvcPaging;
using HMS.Utility;
using HMS.Service.Models;
using Repository.Pattern.UnitOfWork;
using HMS.Service.ViewModels;
using HMS.Entities.ViewModels;
using MvcSiteMapProvider.Web.Html.Models;
using System.IO;
using System.Text;
namespace HMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventService _iEventService;
        private readonly IHomePageViewModelService _iHomePageViewModelService;

        public HomeController(IUnitOfWork unitOfWork, IEventService iEventService, IHomePageViewModelService iHomePageViewModelService)
        {
            _iHomePageViewModelService = iHomePageViewModelService;
            _iEventService = iEventService;
            _unitOfWork = unitOfWork;

        }
        //
        // GET: /Home/
        HMSContext objHMSContext = new Models.HMSContext();
        private const int PAGE_SIZE = 3;
        public ActionResult IndexTest()
        {
            return View();
        }
        public ActionResult SiteMap()
        {
            //var stringBuilder = new StringBuilder();
            //stringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            //stringBuilder.AppendLine("<sitemapindex xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");
            //stringBuilder.AppendLine("<sitemap>");
            //stringBuilder.AppendLine("<loc>http://sprint-newhomes.move.com/sitemaps/sitemap_01.xml</loc>");
            //stringBuilder.AppendLine("<lastmod>" + DateTime.Now.ToString("MMMM-dd-yyyy HH:mm:ss tt") + "</lastmod>");
            //stringBuilder.AppendLine("</sitemap>");
            //stringBuilder.AppendLine("<sitemap>");
            //stringBuilder.AppendLine("<loc>http://sprint-newhomes.move.com/sitemaps/sitemap_02.xml</loc>");
            //stringBuilder.AppendLine("<lastmod>" + DateTime.Now.ToString("MMMM-dd-yyyy HH:mm:ss tt") + "</lastmod>");
            //stringBuilder.AppendLine("</sitemap>");
            //stringBuilder.AppendLine("</sitemapindex>");

            //var ms = new MemoryStream(Encoding.ASCII.GetBytes(stringBuilder.ToString()));



            //Response.AppendHeader("Content-Disposition", "inline;filename=sitemapindex.xml");
            //return new FileStreamResult(ms, "text/xml");
            //SiteContents.
            // SiteMap  a= new SiteMap();
            //  SiteMap.
            //// var 
            // return Content("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +  MvcSiteMapProvider.SiteMap.ToString(), "text/xml");
            return View();
        }

        public ActionResult moc(string searchinfo, int? page)
        {
            var homePage = _iHomePageViewModelService.GetHomePageInfo();
            return View(homePage);
        }


        public ActionResult moc1()
        {
            return View();
        }
        public ActionResult moc2()
        {
            return View("moc2");
        }
        public ActionResult moc3()
        {
            return View("moc3");
        }
        public ActionResult moc4()
        {
            var homePage = _iHomePageViewModelService.GetHomePageInfoForMoc4();
            return View(homePage);
        }
        public ActionResult moc5()
        {
            var homePage = _iHomePageViewModelService.GetHomePageInfoForMoc4();
            return View(homePage);
        }
        public ActionResult moc6()
        {
            var homePage = _iHomePageViewModelService.GetHomePageInfoForMoc4();
            return View(homePage);
        }
        [HttpPost]
        public ActionResult AddEmail(string email)
        {
            try
            {
                if (utility.Emailer.SendMail(email, HMSContent.noreply, HMSContent.SubscriberMailSubject, HMSContent.SubscriberMailBody))
                {
                    HMS.Models.Subscribe objSubscribe = new Subscribe();
                    objSubscribe.Email = email;
                    objSubscribe.SetDate = DateTime.Now;
                    objHMSContext.Subscribes.Add(objSubscribe);
                    objHMSContext.SaveChanges();
                    TempData.Add("success", "Data inserted successfully");
                    return RedirectToAction("Index");
                }

            }
            catch (DataException ex)
            {
                TempData.Add("error", ex.InnerException.InnerException.Message);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        public ActionResult test()
        {
            return View();
        }

        public void SetDefaultImage()
        {
            List<Advertise> DefaultAdds = objHMSContext.Advertises.Where(x => x.IsActive == true && x.IsDefault == true).ToList();

        }

        public ActionResult SearchHotel(HajjHome SearchCriteria)
        {
            //gatting date from to date

            string Fromday = "depdate-day=" + DateTime.Now.AddDays(3).Day.ToString() + "&";
            string Frommonth = "depdate-month=" + DateTime.Now.AddDays(3).Month.ToString() + "&";
            string Fromyear = "depdate-year=" + DateTime.Now.AddDays(3).Year.ToString() + "&";
            string Fromdate = Fromday + Frommonth + Fromyear;

            string nights = "nights=" + utility.utility.getDuration(SearchCriteria.SelectedDuration).ToString() + "&";

            string hotelclass = SearchCriteria.SelectedClass.ToString();
            if (SearchCriteria.SelectedClass == 1)
            {
                hotelclass = "";
            }
            else
            {
                hotelclass = (SearchCriteria.SelectedClass - 1).ToString();
            }


            string rating = "rating=" + hotelclass + "&";

            string SearchURL = "http://search.al-hidaayah.travel/fusion/start.pl?sid=11488&product=hotel&searchby=dest&formno=1&ctl00%24main_content%24SideBar%24Interest=HotelsInterestRadio&country=United+Arab+Emirates&destair=DXB&[Fromdate][nights]roomcount=2&adults-1=2&children-1=0&adults-2=1&children-2=0&adults-3=1&children-3=0&[rating]board=&wantedname=&childage-1-1=-&childage-1-2=-&childage-1-3=-&childage-1-4=-&childage-1-5=-&childage-2-1=-&childage-2-2=-&childage-2-3=-&childage-2-4=-&childage-2-5=-&childage-3-1=-&childage-3-2=-&childage-3-3=-&childage-3-4=-&childage-3-5=-&ctl00%24main_content%24SideBar%24advanced_search=Search";
            string SessionURL = "http://search.al-hidaayah.travel/fusion/displayhotels.pl?sessionkey=[SessionKey]" + "&resultkey=default";
            SearchURL = SearchURL.Replace("[Fromdate]", Fromdate).Replace("[nights]", nights).Replace("[rating]", rating);
            //SearchURL = SearchURL.Replace("[Fromdate]", Fromdate).Replace("[Todate]", ToDate).Replace("[Duration]", duration);


            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load(SearchURL);

            string[] stringSeparators1 = new string[] { "sessionkey=" };
            string[] stringSeparators2 = new string[] { "');\n//-->" };
            string SessionKeyContain = doc.DocumentNode.OuterHtml.Split(stringSeparators1, StringSplitOptions.None)[1];
            string SessionKey = SessionKeyContain.Split(stringSeparators2, StringSplitOptions.None)[0];


            SessionURL = SessionURL.Replace("[SessionKey]", SessionKey);
            HtmlWeb hwResult = new HtmlWeb();
            HtmlDocument docResult = hw.Load(SessionURL);
            docResult.DocumentNode.SelectSingleNode("//div[@id='hotelresultsheader']").Remove();


            //Delete unwanted image
            HtmlNodeCollection removeHotelImageNode = docResult.DocumentNode.SelectNodes("//td[@class='resultsimage']");
            HtmlNodeCollection removeNotFoundImageNode = docResult.DocumentNode.SelectNodes("//div[@id='hotelresults']/img");



            foreach (var node in removeHotelImageNode)
            {
                docResult.DocumentNode.SelectSingleNode(node.XPath).Remove();
            }

            foreach (var imgnode in removeNotFoundImageNode)
            {
                docResult.DocumentNode.SelectSingleNode(imgnode.XPath).Remove();
            }


            string SearchResult = docResult.DocumentNode.SelectSingleNode("//div[@id='left_column']").InnerHtml;

            SearchResult = SearchResult.Replace("hoteldesctable", "table").Replace("roomsrow", "table");//bootstrap table css
            SearchResult = SearchResult.Replace("/images/dynapack/nopicture.gif", "http://search.al-hidaayah.travel/images/dynapack/nopicture.gif");//bootstrap table css

            HMS.ViewModels.Search objSearch = new Search();

            objSearch.SearchResultInfo = MvcHtmlString.Create(SearchResult.Replace("display:none", "display:block"));
            return View(objSearch);
        }


        public ActionResult SearchFlieght(HajjHome SearchCriteria)
        {
            //gatting date from to date

            string Fromday = "depdate-day=" + DateTime.Now.AddDays(3).Day.ToString() + "&";
            string Frommonth = "depdate-month=" + DateTime.Now.AddDays(3).Month.ToString() + "&";
            string Fromyear = "depdate-year=" + DateTime.Now.AddDays(3).Year.ToString() + "&";
            string Fromdate = Fromday + Frommonth + Fromyear;



            string Today = "retdate-day=" + DateTime.Now.AddDays(10).Day.ToString() + "&";
            string Tomonth = "retdate-month=" + DateTime.Now.AddDays(10).Month.ToString() + "&";
            string Toyear = "retdate-year=" + DateTime.Now.AddDays(10).Year.ToString() + "&";

            string ToDate = Today + Tomonth + Toyear;//"retdate-day=12&retdate-month=3&retdate-year=2014&";
            string duration = "helpernights=" + utility.utility.getDuration(SearchCriteria.SelectedDuration).ToString();


            string SearchURL = "http://search.al-hidaayah.travel/fusion/start.pl?sid=12121&product=flight&searchby=dest&formno=1&sessionkey=&resultkey=random&carriertype=&depair=LGW&country=Saudi+Arabia&destair=JED&[Fromdate][Todate][Duration]&indepartcode=JED&inarrivecode=LHR&adults=2&children=0&infants=0&flightclass=&airline=&childage-1=-&childage-2=-&childage-3=-&childage-4=-&childage-5=-&ctl00%24main_content%24SideBar%24advanced_search=Search";
            string SessionURL = "http://search.al-hidaayah.travel/fusion/displayflights.pl?sessionkey=";

            SearchURL = SearchURL.Replace("[Fromdate]", Fromdate).Replace("[Todate]", ToDate).Replace("[Duration]", duration);


            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load(SearchURL);

            string[] stringSeparators1 = new string[] { "sessionkey=" };
            string[] stringSeparators2 = new string[] { "');\n//-->" };
            string SessionKeyContain = doc.DocumentNode.OuterHtml.Split(stringSeparators1, StringSplitOptions.None)[1];
            string SessionKey = SessionKeyContain.Split(stringSeparators2, StringSplitOptions.None)[0];


            SessionURL = SessionURL + SessionKey;
            HtmlWeb hwResult = new HtmlWeb();
            HtmlDocument docResult = hw.Load(SessionURL);
            docResult.DocumentNode.SelectSingleNode("//div[@id='flightresultsheader']").Remove();
            string SearchResult = docResult.DocumentNode.SelectSingleNode("//div[@id='left_column']").InnerHtml;


            HMS.ViewModels.Search objSearch = new Search();

            objSearch.SearchResultInfo = MvcHtmlString.Create(SearchResult.Replace("display:none", "display:block"));
            return View(objSearch);
        }

        [MetaKeywords("hajj,hajj 2014,hajj seminar 2014,hajj packages,hajj and umrah,hajj tours,hajj 2015,hajj facts,hajj pilgrimage,hajj 2014 packages uk,hajj guide,hajj packages 2015")]
        [MetaDescription("Coming Soon, the most comprehensive hajj and umrah website that will change the way people search and book hajj and umrah trips")]
        public ActionResult Index(string typeId, int? page)
        {
            Event objEvent = new Event();
            ViewBag.EventType = objEvent.Types;

            ViewData["typeId"] = typeId;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<HMS.Entities.Models.Event> lstEvent = _iEventService.GetActivEvent(true).Where(x => x.IsVisible == true).OrderByDescending(x => x.EventsDate).ToList();
            lstEvent = string.IsNullOrWhiteSpace(typeId) ? lstEvent.ToPagedList(currentPageIndex, PAGE_SIZE) : lstEvent.Where(p => p.EventsTitle.ToLower().Contains(typeId.ToLower())).ToPagedList(currentPageIndex, PAGE_SIZE);
            return View(lstEvent);
        }

    }
}
