using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Subscribe
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public System.DateTime SetDate { get; set; }
    }
}
