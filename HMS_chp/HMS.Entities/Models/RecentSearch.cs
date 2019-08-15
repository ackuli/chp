using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class RecentSearch
    {
        public int Id { get; set; }
        public string SessionKey { get; set; }
        public string From { get; set; }
        public int Duration { get; set; }
        public int PepolePerRoom { get; set; }
        public int HotelClass { get; set; }
        public System.DateTime SetDate { get; set; }
    }
}
