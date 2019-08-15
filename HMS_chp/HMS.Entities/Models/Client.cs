using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Client
    {
        public Client()
        {
            this.ClientInformations = new List<ClientInformation>();
            this.PackagesInfoes = new List<PackagesInfo>();
            this.RoleRightsses = new List<RoleRightss>();
            this.UserAccounts = new List<UserAccount>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string SetBy { get; set; }
        public System.DateTime Setdate { get; set; }
        public string Address { get; set; }
        public string Tellandline { get; set; }
        public string TelMobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string YearEstablished { get; set; }
        public Nullable<bool> IsApprovedbySaudiHajjMinistry { get; set; }
        public bool IsHajjApproval { get; set; }
        public string HajjApprovalLicienceNumberNo { get; set; }
        public bool IsUmarhApproval { get; set; }
        public string UmarhApprovalLicienceNumberNo { get; set; }
        public Nullable<decimal> MinistryApprovalNumber { get; set; }
        public string Approvedfor { get; set; }
        public bool ATOLApproved { get; set; }
        public Nullable<decimal> ATOLLicense { get; set; }
        public Nullable<decimal> IATANo { get; set; }
        public Nullable<decimal> CompanyRegistrationNumber { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public virtual ICollection<ClientInformation> ClientInformations { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfoes { get; set; }
        public virtual ICollection<RoleRightss> RoleRightsses { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
