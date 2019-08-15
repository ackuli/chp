using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Experience
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Year { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Narratives { get; set; }
        public Nullable<bool> IsShow { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public System.DateTime Setdate { get; set; }
    }
}
