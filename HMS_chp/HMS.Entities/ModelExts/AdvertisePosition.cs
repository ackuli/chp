using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class AdvertisePosition : Entity
    {
        public  IEnumerable<Advertis> advertisList { get; set; }
        public List<KeyValuePair<int, string>> pageTypeList { get; set; }
        public List<KeyValuePair<int, string>> currencyTypeList { get; set; }       
     }
}
