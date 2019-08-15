using HMS.Entities.ViewModels;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Advertis:Entity
    {
        public List<KeyValuePair<int, string>> advertiseTypeList { get; set; }
        public List<KeyValuePair<int, string>> clientList { get; set; }
        public List<BinaryObject> binaryObjectList;
        public List<AdvertiseContent> advertiseContentList;
        public AdvertiseContent advertiseContent;
    }
}
