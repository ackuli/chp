using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class AdvertiseType
    {
        public AdvertiseType()
        {
            this.Advertises = new List<Advertis>();
        }

        public int AdvertiseTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Advertis> Advertises { get; set; }
    }
}
