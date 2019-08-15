using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Duration
    {
        public Duration()
        {
            this.PackagesInfoes = new List<PackagesInfo>();
        }

        public int DurationId { get; set; }
        public string DuratioName { get; set; }
        public Nullable<System.DateTime> SetDate { get; set; }
        public string SetBy { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfoes { get; set; }
    }
}
