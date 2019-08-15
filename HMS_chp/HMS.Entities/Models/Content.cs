using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Content
    {
        public int ContentId { get; set; }
        public Nullable<int> ContentNameId { get; set; }
        public string ContentName { get; set; }
        public string ContentURL { get; set; }
        public string ContentHeader { get; set; }
        public string ContentSubHeader { get; set; }
        public Nullable<int> ContentTypeId { get; set; }
        public string TextContent { get; set; }
        public byte[] ImageContent { get; set; }
        public byte[] VedioContent { get; set; }
        public string DocumentContent { get; set; }
        public string ContentExtention { get; set; }
    }
}
