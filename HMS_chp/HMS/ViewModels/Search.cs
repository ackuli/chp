using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Models;
using System.Web.Mvc;
namespace HMS.ViewModels
{
    public class Search
    {
        public List<Advertise> lstAdvertise { get; set; }

        public MvcHtmlString SearchResultInfo { get; set; } 
    }
}