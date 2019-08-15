using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Package
    {
        public Package()
        {
            this.PackageDetails = new List<PackageDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PackageSourceId { get; set; }
        public string Details { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public string PriceType { get; set; }
        public string StartFrom { get; set; }
        public string SetBy { get; set; }
        public string SetDate { get; set; }
        public virtual ICollection<PackageDetail> PackageDetails { get; set; }
        public virtual PackageSource PackageSource { get; set; }
    }
}
