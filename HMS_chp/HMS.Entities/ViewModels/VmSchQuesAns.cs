using HMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.ViewModels
{
   public class VmSchQuesAns
   {
       public QuestionAnswer quesAns { get; set; }
       public List<Scholare> scholareList { get; set; }
   }
}
