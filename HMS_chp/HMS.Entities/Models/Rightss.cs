using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Rightss
    {
        public Rightss()
        {
            this.RoleRightsses = new List<RoleRightss>();
        }

        public int RightsId { get; set; }
        public string RightsName { get; set; }
        public string IsActive { get; set; }
        public virtual ICollection<RoleRightss> RoleRightsses { get; set; }
    }
}
