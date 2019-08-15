using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
   public partial class QuestionTypeMetadata
    {
       [Display(Name = "Question Category")]      
       public string Id { get; set; }
    }
}
