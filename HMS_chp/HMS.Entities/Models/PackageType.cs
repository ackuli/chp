using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class PackageType
    {
        public PackageType()
        {
            this.PackagesInfoes = new List<PackagesInfo>();
        }

        public int PackageTypeId { get; set; }
        public string PackageTypename { get; set; }
        public Nullable<System.DateTime> SetDate { get; set; }
        public string SetBy { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfoes { get; set; }
    }
}
