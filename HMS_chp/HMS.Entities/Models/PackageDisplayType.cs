using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class PackageDisplayType
    {
        public PackageDisplayType()
        {
            this.PackagesInfoes = new List<PackagesInfo>();
        }

        public int PackageDisplayTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfoes { get; set; }
    }
}
