using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HMS.ViewModels
{
    public class AdvertiseVM1
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string AddLocation { get; set; }
        public int PositionId { get; set; }
        public string Extension { get; set; }
    }
}