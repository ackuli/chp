using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Duration1
    {
        public int Id { get; set; }
        public string TotalDuration { get; set; }
        public string Description { get; set; }
        public System.DateTime SetDate { get; set; }
        public string SetBy { get; set; }
    }
}
