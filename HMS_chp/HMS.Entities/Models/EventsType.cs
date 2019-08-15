using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class EventsType
    {
        public EventsType()
        {
            this.Events = new List<Event>();
        }

        public int EventsTypeId { get; set; }
        public string EventsTypeName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
