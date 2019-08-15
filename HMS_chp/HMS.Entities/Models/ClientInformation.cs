using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class ClientInformation
    {
        public int ClientInfoId { get; set; }
        public int ClientId { get; set; }
        public string Address { get; set; }
        public string Tellandline { get; set; }
        public string TelMobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string YearEstablished { get; set; }
        public bool IsApprovedbySaudiHajjMinistry { get; set; }
        public Nullable<decimal> MinistryApprovalNumber { get; set; }
        public string Approvedfor { get; set; }
        public bool ATOLApproved { get; set; }
        public Nullable<decimal> ATOLLicense { get; set; }
        public Nullable<decimal> IATANo { get; set; }
        public Nullable<decimal> CompanyRegistrationNumber { get; set; }
        public string Remarks { get; set; }
        public string SetBy { get; set; }
        public System.DateTime SetDate { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public virtual Client Client { get; set; }
    }
}
