using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class PageInfo
    {
        public int PageInfoId { get; set; }
        public string PageName { get; set; }
        public string PageMainHeading { get; set; }
        public string PageMainHeadingDetails { get; set; }
        public string PageURL { get; set; }
        public Nullable<int> PageDownload { get; set; }
        public Nullable<int> PageView { get; set; }
    }
}
