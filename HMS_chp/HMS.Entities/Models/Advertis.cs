using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Advertis
    {
        public int AdvertiseId { get; set; }
        public string Name { get; set; }
        public int AdvertiseTypeId { get; set; }
        public string Extension { get; set; }
        public string AdvertiseContent { get; set; }
        public int AdvertisePositionsId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> ClientId { get; set; }
        public bool IsDefault { get; set; }
        public string SetBy { get; set; }
        public System.DateTime SetDate { get; set; }
        public Nullable<int> Img { get; set; }
        public Nullable<System.DateTime> LastUpdatedTime { get; set; }
        public Nullable<int> PriorityLevel { get; set; }
        public virtual AdvertisePosition AdvertisePosition { get; set; }
        public virtual AdvertiseType AdvertiseType { get; set; }
        public virtual ClientInfo ClientInfo { get; set; }
    }
}
