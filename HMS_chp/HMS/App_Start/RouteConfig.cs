using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
              name: "Hajj and Umrah Packages",
              url: "Home",
              defaults: new { controller = "Home", action = "moc6", id = UrlParameter.Optional },
              namespaces: new[] { "HMS.Controllers" }
           );
            routes.MapRoute(
               name: "Hajj events",
               url: "Hajj-Events-Details/{id}",
               defaults: new { controller = "Events", action = "Details", id = UrlParameter.Optional },
               namespaces: new[] { "HMS.Controllers" }
            );
            routes.MapRoute(
            name: "Hajj-news events",
            url: "NewsAndEvents",
            defaults: new { controller = "newsAndEvents", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );
            routes.MapRoute(
            name: "Guides",
            url: "Guides",
            defaults: new { controller = "Information", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );
            routes.MapRoute(
            name: "Ask The Scholar",
            url: "Ask-The-Scholar",
            defaults: new { controller = "QuestionAnswer", action = "IndexForClient", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );

            //Footer   

            routes.MapRoute(
         name: "Site Map",
         url: "sitemap.xml",
         defaults: new { controller = "Home", action = "SiteMap", id = UrlParameter.Optional },
         namespaces: new[] { "HMS.Controllers" }
      );

            routes.MapRoute(
          name: "StatusAndRewardOfHajjInIslam",
          url: "Information/Status-and-reward-of-hajj-in-Islam",
          defaults: new { controller = "Footer", action = "StatusAndRewardOfHajjInIslam", id = UrlParameter.Optional },
          namespaces: new[] { "HMS.Controllers" }
          );



            routes.MapRoute(
            name: "WhichTypeHajjChoose",
            url: "Information/Which-type-of-hajj-to-choose",
            defaults: new { controller = "Footer", action = "WhichTypeHajjChoose", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );
            routes.MapRoute(
            name: "Hajjritesataglance",
            url: "Information/Hajj-rites-at-a-glance",
            defaults: new { controller = "Footer", action = "Hajjritesataglance", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );

            routes.MapRoute(
            name: "UmrahRitesAtAGlance",
            url: "Information/'Umrah-rites-at-a-glance",
            defaults: new { controller = "Footer", action = "UmrahRitesAtAGlance", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );
            routes.MapRoute(
            name: "miqat",
            url: "Information/What-is-miqat",
            defaults: new { controller = "Footer", action = "miqat", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );

            routes.MapRoute(
            name: "How to perform tawaf",
            url: "Information/How-to-perform-tawaf",
            defaults: new { controller = "Footer", action = "Tawaf", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );

            routes.MapRoute(
            name: "Sai",
            url: "Information/How-to-perform-sai",
            defaults: new { controller = "Footer", action = "Sai", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );
            routes.MapRoute(
            name: "Stepbystepguidetohajjrites",
            url: "Information/Step-by-step-guide-to-hajj-rites",
            defaults: new { controller = "Footer", action = "Stepbystepguidetohajjrites", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );
            routes.MapRoute(
            name: "StepByStepGuideToUmrahHajj",
            url: "Information/Step-by-step-guide-to-‘Umrah-Hajj",
            defaults: new { controller = "Footer", action = "StepByStepGuideToUmrahHajj", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );

            routes.MapRoute(
            name: "HajjWoman",
            url: "Information/Hajj-of-a-woman",
            defaults: new { controller = "Footer", action = "HajjWoman", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );

            routes.MapRoute(
            name: "HajjUmrahGlossary",
            url: "Information/Hajj-and-Umrah-glossary",
            defaults: new { controller = "Footer", action = "HajjUmrahGlossary", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );


            routes.MapRoute(
            name: "ChoosingAgent",
            url: "Information/Choosing-an-Agent",
            defaults: new { controller = "Footer", action = "ChoosingAgent", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );


            routes.MapRoute(
            name: "UnderstandingPackages",
            url: "Information/How-to-understand-a-hajj-package",
            defaults: new { controller = "Footer", action = "UnderstandingPackages", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );

            routes.MapRoute(
            name: "ShiftingPackages",
            url: "Information/What-is-a-Shifting-Package",
            defaults: new { controller = "Footer", action = "ShiftingPackages", id = UrlParameter.Optional },
            namespaces: new[] { "HMS.Controllers" }
            );


            routes.MapRoute(
           name: "HajjUmrahVisas",
           url: "Information/How-Hajj-and-Umrah-Visas-are-processed",
           defaults: new { controller = "Footer", action = "HajjUmrahVisas", id = UrlParameter.Optional },
           namespaces: new[] { "HMS.Controllers" }
           );


            routes.MapRoute(
           name: "HealthConsiderations",
           url: "Information/Health-Considerations",
           defaults: new { controller = "Footer", action = "HealthConsiderations", id = UrlParameter.Optional },
           namespaces: new[] { "HMS.Controllers" }
           );

            routes.MapRoute(
              name: "TravelItemRecommandations",
              url: "Information/Recommended-Travel-Items",
              defaults: new { controller = "Footer", action = "TravelItemRecommandations", id = UrlParameter.Optional },
              namespaces: new[] { "HMS.Controllers" }
              );

            routes.MapRoute(
              name: "Accommodation",
              url: "Information/Accommodation",
              defaults: new { controller = "Footer", action = "Accommodation", id = UrlParameter.Optional },
              namespaces: new[] { "HMS.Controllers" }
              );

            routes.MapRoute(
              name: "FactsAboutSaudiArabia",
              url: "Information/Facts-About-Saudi-Arabia",
              defaults: new { controller = "Footer", action = "FactsAboutSaudiArabia", id = UrlParameter.Optional },
              namespaces: new[] { "HMS.Controllers" }
              );

            routes.MapRoute(
           name: "ContactUs",
           url: "Contact-Us",
           defaults: new { controller = "ContactUs", action = "Create", id = UrlParameter.Optional },
           namespaces: new[] { "HMS.Controllers" }
           );
            routes.MapRoute(
         name: "createFromClient",
         url: "list-your-event",
         defaults: new { controller = "Events", action = "createFromClient", id = UrlParameter.Optional },
         namespaces: new[] { "HMS.Controllers" }
         );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "moc6", id = UrlParameter.Optional },
                 namespaces: new[] { "HMS.Controllers" }
            );

        }
    }
}