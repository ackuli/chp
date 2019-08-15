using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class PageInfoDetail
    {
        public int PageInfoDetailsId { get; set; }
        public int PageInfoId { get; set; }
        public string PageSubHeading { get; set; }
        public string PageInfoDetails { get; set; }
    }
}
