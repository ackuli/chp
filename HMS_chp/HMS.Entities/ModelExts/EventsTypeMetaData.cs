using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
   public partial class EventsTypeMetaData
    {
         [Display(Name = "Event Type Name")]
        [Required(ErrorMessage = "The Event Type Required")]
       public string EventsTypeName { get; set; }


    }
}
