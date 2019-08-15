using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    public partial class QuestionMetaData
    {

        [Display(Name = "Question Id")]
       
        public int QuestionId { get; set; }


        [Display(Name = "Question SL No")]
        public int? QuestionSLNo { get; set; }


        [Display(Name = "Question Text")]
        [Required(ErrorMessage = "The Question Text field is required.")]
        [StringLength(8000)]
        public string QuestionText { get; set; }
         [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
