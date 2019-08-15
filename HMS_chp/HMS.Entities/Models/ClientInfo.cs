using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class ClientInfo
    {
        public ClientInfo()
        {
            this.Advertises = new List<Advertis>();
        }

        public int ClientId { get; set; }
        public string ClientIdentityId { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> Setdate { get; set; }
        public System.DateTime LastUpdatedTime { get; set; }
        public string SetBy { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Img { get; set; }
        public int CurrencyType { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> CountryId { get; set; }
        public virtual ICollection<Advertis> Advertises { get; set; }
        public virtual Country Country { get; set; }
        public virtual CurrencyType CurrencyType1 { get; set; }
    }
}
