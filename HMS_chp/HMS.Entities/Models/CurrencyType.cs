using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class CurrencyType
    {
        public CurrencyType()
        {
            this.AdvertisePositions = new List<AdvertisePosition>();
            this.ClientInfoes = new List<ClientInfo>();
            this.PackagesInfoes = new List<PackagesInfo>();
        }

        public int CurrencyTypeId { get; set; }
        public string CurrencyName { get; set; }
        public virtual ICollection<AdvertisePosition> AdvertisePositions { get; set; }
        public virtual ICollection<ClientInfo> ClientInfoes { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfoes { get; set; }
    }
}
