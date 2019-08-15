using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.ViewModels;
using HtmlAgilityPack;
using HMS.Models;
using MvcPaging;

namespace HMS.Controllers
{
    public class PackageController : Controller
    {
        //
        // GET: /Package/
        HMSContext _context = new Models.HMSContext();
        private const int PAGE_SIZE = 5;
        public ActionResult Index(string searchinfo, int? page, int? PackageSourceId)
        {
            ViewData["searchinfo"] = searchinfo;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<HMS.Models.Package> lstPackages;
            if (PackageSourceId == null)
                lstPackages = _context.Packages.ToList();
            else
                lstPackages = _context.Packages.Where(x => x.PackageSourceId == PackageSourceId).ToList();



            if (string.IsNullOrWhiteSpace(searchinfo))
            {
                lstPackages = lstPackages.ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            else
            {
                lstPackages = lstPackages.Where(p => p.Name.ToLower().Contains(searchinfo.ToLower())).ToPagedList(currentPageIndex, PAGE_SIZE);
            }

            return View(lstPackages);

        }

        public ActionResult AlHadiaPackages()
        {
            _context.Database.ExecuteSqlCommand("delete Packages where PackageSourceId = 1");

            Packages objPackages = new Packages();
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load("https://hajj.al-hidaayah.travel/hajj-packages/");


            var Package = doc.DocumentNode.SelectSingleNode("//table[@class='about-table']").InnerHtml;
            objPackages.Package = MvcHtmlString.Create(Package.ToString());



            //Remove Unwanted value
            HtmlNodeCollection removeNodes = doc.DocumentNode.SelectNodes("//tr[@class='about-table-tabs']");
            foreach (var node in removeNodes)
            {
                doc.DocumentNode.SelectSingleNode(node.XPath).Remove();
            }



            HtmlNodeCollection PackageAttributes = doc.DocumentNode.SelectNodes("//table[@class='about-table-labels']//tbody//td");
            HtmlNodeCollection Packages = doc.DocumentNode.SelectNodes("//table[@class='about-table-info']//th");
            HtmlNodeCollection PackagesAttributeValue = doc.DocumentNode.SelectNodes("//table[@class='about-table-info']//tbody//tr");





            string[] PackagePrices =
                    PackagesAttributeValue[9].InnerText.Trim().Split(new string[] { "\n              \n              \n                " }, StringSplitOptions.None);

            int loopcnt = 0;
            foreach (var VARIABLE in Packages)
            {
                HMS.Models.Package objPackage = new Package();
                string[] PackageInfo = VARIABLE.InnerText.Split(new string[] { "\n" }, StringSplitOptions.None);
                string[] priceInfo = PackagePrices[loopcnt].Split(new string[] { ";" }, StringSplitOptions.None);
                objPackage.Name = PackageInfo[1].Trim();
                objPackage.StartFrom = PackageInfo[2].Trim();
                //Converter week to day
                if (objPackage.Name.Contains("WEEK"))
                {
                    objPackage.Duration = 7 * Convert.ToInt16(PackageInfo[1].Trim().Split(new string[] { " " }, StringSplitOptions.None)[0].Trim());
                }
                else
                {
                    objPackage.Duration = Convert.ToInt16(PackageInfo[1].Trim().Split(new string[] { " " }, StringSplitOptions.None)[0].Trim());
                }

                objPackage.Details = VARIABLE.InnerText.Trim();
                objPackage.PackageSourceId = 1;



                objPackage.Price = Convert.ToInt32(priceInfo[1]);
                if (priceInfo[0] == "&pound")
                {
                    objPackage.PriceType = "£";
                }
                else
                {
                    objPackage.PriceType = priceInfo[0];
                }
                objPackage.SetBy = "Admin";

                objPackage.SetDate = DateTime.Now.ToString("dd-MMM-yyyy");
                _context.Packages.Add(objPackage);
                _context.SaveChanges();
                loopcnt++;
            }

            /*
            foreach (var VARIABLE in PackagesAttributeValue)
            {

            }


            string PackageAttribute = string.Empty;
            foreach (var VARIABLE in PackageAttributes)
            {
                PackageAttribute += VARIABLE.InnerHtml + "</br>";
            }
            objPackages.Package = MvcHtmlString.Create(PackageAttribute);
             */
            TempData.Add("status", "Data inserted Successfully");
            return View();
        }


        public ActionResult ZamZamPackages()
        {
            _context.Database.ExecuteSqlCommand("delete Packages where PackageSourceId = 2");
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load("http://www.zamzamtravels.org.uk/");

            doc.DocumentNode.SelectSingleNode("//div[@id='gkMainbodyTop']").Remove();

            var Package = doc.DocumentNode.SelectNodes("//div[@class='nspArt']");
            int loopcnt = 0;
            foreach (var SinglePackageInfo in Package)
            {
                HMS.Models.Package objPackage = new Package();
                List<string> PackageInfoTtribute = SinglePackageInfo.InnerText.Replace("\t", "").Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                // checking PackageInfoTtribute.Count() > 1 then this is the real package
                if (PackageInfoTtribute.Count() > 1)
                {
                    objPackage.Name = PackageInfoTtribute[0];
                    //if package peice == SOLD then peice = 0
                    if (PackageInfoTtribute[1].Trim().Replace(",", "").Substring(1) != "SOLD")
                    {
                        objPackage.Price = Convert.ToInt32(PackageInfoTtribute[1].Trim().Replace(",", "").Substring(1));
                    }
                    else
                    {
                        objPackage.Price = 0;
                    }
                    objPackage.PriceType = PackageInfoTtribute[1].Trim().Replace(",", "").Substring(0, 1);
                    //PackageInfoTtribute.Count() > 5 means package with duration and start date
                    if (PackageInfoTtribute.Count() > 5)
                    {
                        objPackage.StartFrom = PackageInfoTtribute[2].Substring(10).Trim();
                        //Remove or
                        string enddate = PackageInfoTtribute[3].Substring(8).Trim();
                        //double start date. Remove the first one
                        if (enddate.Contains("or") == true)
                        {
                            enddate = enddate.Split(new string[] { "or" }, StringSplitOptions.None)[1].Trim();
                        }
                        string startdate = PackageInfoTtribute[2].Substring(10).Trim();
                        if (startdate.Contains("or") == true)
                        {
                            startdate = startdate.Split(new string[] { "or" }, StringSplitOptions.None)[1].Trim();
                        }

                        objPackage.Duration = (Convert.ToDateTime(enddate) - Convert.ToDateTime(startdate)).Days;
                        //objPackage.Duration = 10;
                    }
                    else
                    {
                        objPackage.StartFrom = "NULL";
                        objPackage.Duration = 0;

                    }
                    objPackage.Details = string.Join(",", PackageInfoTtribute);
                    objPackage.PackageSourceId = 2;
                    objPackage.SetBy = "Admin";
                    objPackage.SetDate = DateTime.Now.ToString("dd-MMM-yyyy");
                    _context.Packages.Add(objPackage);
                    _context.SaveChanges();
                }
            }
            TempData.Add("status", "Data inserted Successfully");
            return View();
        }

        public ActionResult PackageInfo(string searchinfo, int? page)
        {
            ViewData["searchinfo"] = searchinfo;
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<HMS.Models.Package> lstPackages = _context.Packages.ToList();

            if (string.IsNullOrWhiteSpace(searchinfo))
            {
                lstPackages = lstPackages.ToPagedList(currentPageIndex, PAGE_SIZE);
            }
            else
            {
                lstPackages = lstPackages.Where(p => p.Name.ToLower().Contains(searchinfo.ToLower())).ToPagedList(currentPageIndex, PAGE_SIZE);
            }

            return View(lstPackages);

        }

        public ViewResult DeletePackage()
        {
            _context.Database.ExecuteSqlCommand("delete Packages DBCC CHECKIDENT ('Packages', RESEED, 0)");
            TempData.Add("status", "Package has been deleted successfully");
            return View();
        }

        public MvcHtmlString GetZamZamMvcString()
        {
            //Add package information 79.170.44.77:80

            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load("http://www.zamzamtravels.org.uk/");

            //var Package = doc.DocumentNode.SelectSingleNode("//div[@id='gkContentMainbody']").InnerHtml.Replace("header", "pkgHeader").Replace("box nsp color1","span4");
            doc.DocumentNode.SelectSingleNode("//div[@id='gkMainbodyTop']").Remove();
            var Package = doc.DocumentNode.SelectSingleNode("//div[@id='gkContentMainbody']").InnerHtml.Replace("header", "pkgHeader").Replace("box nsp color1", "span4 singlePackage")
            .Replace("href=\"", "target=\"_blank\" href=http://www.zamzamtravels.org.uk").Replace("kingdom\"", "kingdom");


            return MvcHtmlString.Create(Package.ToString());

        }
    }
}
