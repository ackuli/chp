using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class PageType
    {
        public PageType()
        {
            this.AdvertisePositions = new List<AdvertisePosition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AdvertisePosition> AdvertisePositions { get; set; }
    }
}
