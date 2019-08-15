using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Admin.Utility
{
    public class Utility
    {
        public IEnumerable<KeyValuePair<int, string>> RequsitionTypes()
        {
            IEnumerable<KeyValuePair<int, string>> ReqType = new[] 
            {
                new KeyValuePair<int,string>(1,"Stock In"),
                new KeyValuePair<int,string>(2,"Stock Out"),
                new KeyValuePair<int,string>(3,"Stock Return"),
                new KeyValuePair<int,string>(3,"Stock Transfer")
            };
            return ReqType;
        }
    }
}