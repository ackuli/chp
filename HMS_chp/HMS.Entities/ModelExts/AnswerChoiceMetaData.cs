using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
   public partial class AnswerChoiceMetaData
    {

       [Display(Name = "Answer Choice Name")]
       [Required(ErrorMessage = "The Answer Choice Name field is required.")]
       [StringLength(8000)]
        public string Choices { get; set; }
        public int QuestionId { get; set; }
        public bool IsAnswer { get; set; }

        [Display(Name = "Answer Correct Details")]

      
        [StringLength(800)]
        public string WhyAnswerCorrect { get; set; }

       [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
