using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Models;

namespace HMS.ViewModels
{
    public class EventVM
    {
        public Event Event { get; set; }
        public HttpPostedFileBase EventDoc1 { get; set; }
        public HttpPostedFileBase Logo { get; set; }
    }
}