using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class News
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string Description { get; set; }
        public string NewsLink { get; set; }
        public string Source { get; set; }
        public System.DateTime PublishDate { get; set; }
        public Nullable<int> Img { get; set; }
        public bool IsArchive { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        public bool IsVisible { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public System.DateTime SourceDate { get; set; }
    }
}
