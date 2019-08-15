using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class UserAccount
    {
        public int Id { get; set; }
        public string UserAccountsId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string UserDescription { get; set; }
        public System.DateTime SetDate { get; set; }
        public string SetBy { get; set; }
        public string EmailId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string PhoneNo { get; set; }
        public int ClientId { get; set; }
        public bool IsTermConditionAgreed { get; set; }
        public virtual Client Client { get; set; }
        public virtual Country Country { get; set; }
        public virtual Role Role { get; set; }
    }
}
