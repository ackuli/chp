using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class QuizQuestionAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int AnswerChoiceId { get; set; }
        public bool IsActive { get; set; }
        public virtual AnswerChoice AnswerChoice { get; set; }
        public virtual Question Question { get; set; }
    }
}
