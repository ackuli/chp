using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.GData.Analytics;

namespace HMS.Controllers
{
    public class AnalyticsController : Controller
    {
        //
        // GET: /Analytics/

        public ActionResult Index()
        {
            return View();
        }
        private string userName = "mohebbo@gmail.com";
        private string passWord = "mb153519";
        private string profileId = "a35432699w63252094p64895644";
        private const string dataFeedUrl = "https://www.googleapis.com/analytics/v3/data/realtime";
        private string yesterdayDate = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");

        public ActionResult GetPostStats()
        {
            var service = new AnalyticsService("eRecruitmentRunning");

            service.setUserCredentials(userName, passWord);

            var dataQuery = new DataQuery(dataFeedUrl)
            {
                Ids = profileId,
                Metrics = "ga:activeVisitors",
                Sort = "ga:activeVisitors",
                GAStartDate = new DateTime(2013, 2, 11).ToString("yyyy-MM-dd"),
                GAEndDate = DateTime.Now.ToString("yyyy-MM-dd")
            };

            var dataFeed = service.Query(dataQuery);

            var totalEntry = dataFeed.Entries[0];

            ViewData["Total"] = ((DataEntry)(totalEntry)).Metrics[0].Value;

            dataQuery.GAStartDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            dataQuery.GAEndDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            dataFeed = service.Query(dataQuery);

            var yesterdayEntry = dataFeed.Entries[0];
            ViewData["Yesterday"] = ((DataEntry)(yesterdayEntry)).Metrics[0].Value;
            dataQuery.GAStartDate = DateTime.Now.ToString("yyyy-MM-dd");
            dataQuery.GAEndDate = DateTime.Now.ToString("yyyy-MM-dd");
            dataFeed = service.Query(dataQuery);

            var todayEntry = dataFeed.Entries[0];
            ViewData["Today"] = ((DataEntry)(todayEntry)).Metrics[0].Value;

            return PartialView(dataFeed.Entries);
        }
    }
}
