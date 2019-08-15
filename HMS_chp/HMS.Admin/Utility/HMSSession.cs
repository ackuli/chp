using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.Admin.Utility
{
    [Serializable()]
    public sealed class HMSSession
    {
        public int UserPkId { get; set; }
        public string RoleId { get; set; }
        public string UserId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string outboxcnt { get; set; }
        public string inboxcnt { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string projectId { get; set; }
        public List<int?> UserRights { get; set; }

    }
}