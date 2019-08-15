using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            this.HotelDetails = new List<HotelDetail>();
            this.PackagesInfoes = new List<PackagesInfo>();
        }

        public int Id { get; set; }
        public string Star { get; set; }
        public int DistanceFromHaram { get; set; }
        public string Description { get; set; }
        public System.DateTime SetDate { get; set; }
        public virtual ICollection<HotelDetail> HotelDetails { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfoes { get; set; }
    }
}
