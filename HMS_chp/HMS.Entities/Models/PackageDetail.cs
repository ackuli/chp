using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class PackageDetail
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int Details { get; set; }
        public virtual Package Package { get; set; }
    }
}
