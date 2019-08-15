using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Scholare
    {
        public int ScholarId { get; set; }
        public string ScholarName { get; set; }
        public string Scholarbiography { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> Logdate { get; set; }
    }
}
