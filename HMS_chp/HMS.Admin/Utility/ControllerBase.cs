using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Admin.Utility
{
    public class MessInventoryControllerBase : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.count = 20; //Add whatever
            base.OnActionExecuting(filterContext);
        }

    }
}