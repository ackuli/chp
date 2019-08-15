using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Role
    {
        public Role()
        {
            this.RoleRightsses = new List<RoleRightss>();
            this.UserAccounts = new List<UserAccount>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<RoleRightss> RoleRightsses { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
