using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Shifting
    {
        public Shifting()
        {
            this.PackagesInfoes = new List<PackagesInfo>();
        }

        public int ShiftingId { get; set; }
        public string ShiftingName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfoes { get; set; }
    }
}
