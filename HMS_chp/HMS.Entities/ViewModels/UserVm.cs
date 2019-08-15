using HMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.ViewModels
{
    public class VmUser
    {
        public int clientId { get; set; }
        public List<KeyValuePair<int, string>> clientList { get; set; }

        public List<UserAccount> searchData { get; set; }
    }

    public class VmUserPass
    {
        public UserAccount user { get; set; }
        public string ConfirmPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
