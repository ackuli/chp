using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class DistanceUnit
    {
        public DistanceUnit()
        {
            this.PackagesInfoes = new List<PackagesInfo>();
        }

        public int DistanceUnitId { get; set; }
        public string DistanceUnitName { get; set; }
        public string DistanceDescription { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfoes { get; set; }
    }
}
