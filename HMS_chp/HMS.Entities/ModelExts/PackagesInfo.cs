using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
   [MetadataType(typeof(PackagesInfoMetadata))]
    public partial class PackagesInfo : Entity
    {
        public List<KeyValuePair<int, string>> kvpDuration { get; set; }
        public List<KeyValuePair<int, string>> kvpPackagetype { get; set; }

        public List<KeyValuePair<int, string>> kvpCurrencyType { get; set; }

        public List<KeyValuePair<int, string>> kvplistShifting { get; set; }
        public List<KeyValuePair<int, string>> kvplistHotelClass { get; set; }
        public   List<KeyValuePair<int, string>> kvpPeoplePerRoom { get; set; }

        public List<KeyValuePair<int, string>> kvpPackagesubscribe { get; set; }

        public List<KeyValuePair<int, string>> kvpPackageDisplayType { get; set; }

        public List<KeyValuePair<int, string>> kvpDistanceUnit { get; set; }
       
    }
}
