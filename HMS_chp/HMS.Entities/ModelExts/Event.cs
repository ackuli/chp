using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HMS.Entities.Models
{
     [MetadataType(typeof(EventMetaData))]
    public partial class Event : Entity
    {
        public List<KeyValuePair<int, string>> kvpEventType { get; set; }
    }
}
