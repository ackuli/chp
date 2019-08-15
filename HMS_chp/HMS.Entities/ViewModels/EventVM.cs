using HMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HMS.Entities.ViewModels
{
  public  class EventVM
    {
        public Event Event { get; set; }
        public HttpPostedFileBase EventDoc1 { get; set; }
        public HttpPostedFileBase Logo { get; set; }
    }
}
