using HMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.ViewModels
{
    public class HomePageViewModel
    {
        public List<PackagesInfo> lstFeaturedPackages { get; set; }
        public List<Experience> experience { get; set; }
        public IEnumerable<AdvertisePosition> advertisePosition { get; set; }    
        public List<KeyValuePair<int, string>> kvplistHotelClass { get; set; }
        public List<KeyValuePair<int, string>> kvplistPeoplePerRoom { get; set; }
        public List<KeyValuePair<int, string>> kvplistDurations { get; set; }
        public List<KeyValuePair<int, string>> kvplistShifting { get; set; }
        public int? HotelclassId { get; set; }
        public int? DurationId { get; set; }
        public int? PeoplePerRoomsId { get; set; }
        public int? PackagesubscribeId { get; set; }
        public int? ShiftingId { get; set; }
        public string From { get; set; }
        public string IsHajjUmrah { get; set; }
        public string IsUmrah { get; set; }                       
    }
}
