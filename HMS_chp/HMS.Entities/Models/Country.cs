using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Country
    {
        public Country()
        {
            this.ClientInfoes = new List<ClientInfo>();
            this.UserAccounts = new List<UserAccount>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<ClientInfo> ClientInfoes { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
