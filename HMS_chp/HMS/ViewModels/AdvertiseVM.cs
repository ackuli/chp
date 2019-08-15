using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Models;

namespace HMS.ViewModels
{
    public class AdvertiseVM
    {
        public Advertise Advertise { get; set; }
        public HttpPostedFileBase AddPicture { get; set; }
    }
}