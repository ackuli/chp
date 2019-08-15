using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Entities.Models;
using MvcPaging;

namespace HMS.ViewModels
{
    public class newsEventVM
    {
        public IPagedList<Event> LstEvents { get; set; }
        public IPagedList<News> LstNews { get; set; }
        public List<News> LstNewses  { get; set; }
        public List<News> LstArchiveNews { get; set; }
        public IEnumerable<AdvertisePosition> advertisePosition { get; set; }        
    }
}