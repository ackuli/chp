using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HMS.Models;
using System.Web.Mvc;
using MvcPaging;

namespace HMS.ViewModels
{
    public class HajjHome
    {
        [Required]
        public int SelectedDuration { get; set; }
        public List<Duration> Duration { get; set; }
        [Required]
        public int SelectedClass{ get; set; }
        public List<Hotel> HotelClass { get; set; }
        public int SelectedRoomCapacity { get; set; }
        public List<PeoplePerRoom> PeoplePerRoom { get; set; }
        public List<AdvertiseVM1> AdvertiseVM { get; set; }
        //public List<Advertise> Advertises { get; set; }
        public MvcHtmlString PackageInfo { get; set; }
        public string PackageType { get; set; }
        public string To { get; set; }

        public IList<HMS.Models.Package> lstPackages { get; set; }

        public MvcHtmlString position1 { get; set; }
        public MvcHtmlString position2 { get; set; }
        public MvcHtmlString position3 { get; set; }
        public MvcHtmlString position4 { get; set; }

        public List<Experience> experience { get; set; }
    }
}