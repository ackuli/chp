using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class UserAccount : Entity
    {
        public List<KeyValuePair<int, string>> clientList { get; set; }
        public List<KeyValuePair<int, string>> roleList { get; set; }
    }
}
