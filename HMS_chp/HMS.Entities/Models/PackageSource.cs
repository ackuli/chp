using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class PackageSource
    {
        public PackageSource()
        {
            this.Packages = new List<Package>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int LogoId { get; set; }
        public string SetBy { get; set; }
        public System.DateTime SetDate { get; set; }
        public virtual BinaryObject BinaryObject { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
