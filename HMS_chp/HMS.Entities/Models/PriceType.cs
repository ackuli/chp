using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class PriceType
    {
        public PriceType()
        {
            this.PackagesInfoes = new List<PackagesInfo>();
        }

        public int PriceTypeId { get; set; }
        public string PriceTypeName { get; set; }
        public Nullable<System.DateTime> SetDate { get; set; }
        public string SetBy { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfoes { get; set; }
    }
}
