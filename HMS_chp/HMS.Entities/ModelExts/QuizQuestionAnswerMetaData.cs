using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    public partial class QuizQuestionAnswerMetaData
    {
        [Display(Name = "Question Name")]
        public int QuestionId { get; set; }

        [Display(Name = "Answer Choice Name")]
        [Required(ErrorMessage = "The Answer Choice Name field is required.")]

        public int AnswerChoiceId { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
