using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class AdvertisePosition
    {
        public AdvertisePosition()
        {
            this.Advertises = new List<Advertis>();
        }

        public int AdvertisePositionsId { get; set; }
        public string Name { get; set; }
        public string TargetId { get; set; }
        public string Description { get; set; }
        public int PageId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Amount { get; set; }
        public Nullable<int> CurrencyType { get; set; }
        public string SetBy { get; set; }
        public System.DateTime SetDate { get; set; }
        public bool IsDefault { get; set; }
        public Nullable<System.DateTime> LastUpdatedTime { get; set; }
        public virtual CurrencyType CurrencyType1 { get; set; }
        public virtual PageType PageType { get; set; }
        public virtual ICollection<Advertis> Advertises { get; set; }
    }
}
