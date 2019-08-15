using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Entities.Models;
using MvcPaging;

namespace HMS.Entities.ViewModels

{
    public class newsEventVM
    {
        public IPagedList<Event> LstEvents { get; set; }
        public IPagedList<News> LstNews { get; set; }
        public IPagedList<News> LstArchiveNewsPaging { get; set; }
        public List<News> LstNewses  { get; set; }
        public Event Events { get; set; }
        public IEnumerable<Event> EventsList { get; set; }
        public List<News> LstArchiveNews { get; set; }
        public List<Event> LstArchiveEvent { get; set; }
        public List<KeyValuePair<int, string>> EventTypeList { get; set; }
        public IEnumerable<AdvertisePosition> advertisePosition { get; set; }
        public string EventsTypeId { get; set; }
       // public IEnumerable<newsEventVM> GetNewsAndEventsInfo();
    
    }
}