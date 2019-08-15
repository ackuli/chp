using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class RoleRightss
    {
        public int RoleRightsId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> RightId { get; set; }
        public string SetBy { get; set; }
        public bool IsActive { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Rightss Rightss { get; set; }
        public virtual Role Role { get; set; }
    }
}
