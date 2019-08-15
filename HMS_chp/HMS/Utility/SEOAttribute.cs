using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HMS.Utility
{
    public class SEOAttribute:ActionFilterAttribute
    {
        /*
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var keywords = filterContext.ActionDescriptor.GetCustomAttributes(typeof(MetaKeywordsAttribute), false);
            if (keywords.Length == 1)
                filterContext.Controller.ViewData["MetaKeywords"] = keywords.Value;

            var description = filterContext.ActionDescriptor.GetCustomAttributes(typeof(MetaDescriptionAttribute), false);
            if (description.Length == 1)
                filterContext.Controller.ViewData["MetaDescription"] = description.Value;

            base.OnActionExecuting(filterContext);
        }
         * */
    }
    public class MetaDescriptionAttribute :  ActionFilterAttribute
    {
        private readonly string _parameter;

        public MetaDescriptionAttribute(string parameter)
        {
            _parameter = parameter;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var description = filterContext.ActionDescriptor.GetCustomAttributes(typeof(MetaDescriptionAttribute), false);
            if (description.Length == 1)
                filterContext.Controller.ViewData["MetaDescription"] = _parameter;

            base.OnActionExecuting(filterContext);
        }
    }
    public class MetaKeywordsAttribute : ActionFilterAttribute
    {
        private readonly string _parameter;

        public MetaKeywordsAttribute(string parameter)
        {
            _parameter = parameter;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var keywords = filterContext.ActionDescriptor.GetCustomAttributes(typeof(MetaKeywordsAttribute), false);
            if (keywords.Length == 1)
                filterContext.Controller.ViewData["MetaKeywords"] = _parameter;
            base.OnActionExecuting(filterContext);
        }
        
    }
}