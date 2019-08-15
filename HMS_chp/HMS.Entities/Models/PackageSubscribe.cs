using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class PackageSubscribe
    {
        public PackageSubscribe()
        {
            this.PackagesInfoes = new List<PackagesInfo>();
        }

        public int PackagesubscribeId { get; set; }
        public string PackageSubscribeName { get; set; }
        public System.DateTime SetDate { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfoes { get; set; }
    }
}
