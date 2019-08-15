using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Statuss
    {
        public Statuss()
        {
            this.PackagesInfoes = new List<PackagesInfo>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public Nullable<System.DateTime> SetDate { get; set; }
        public string SetBy { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfoes { get; set; }
    }
}
