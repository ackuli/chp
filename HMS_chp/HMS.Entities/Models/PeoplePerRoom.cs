using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class PeoplePerRoom
    {
        public PeoplePerRoom()
        {
            this.PackagesInfoes = new List<PackagesInfo>();
        }

        public int Id { get; set; }
        public string RoomCapacity { get; set; }
        public string Description { get; set; }
        public System.DateTime SetDate { get; set; }
        public string SetBy { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfoes { get; set; }
    }
}
