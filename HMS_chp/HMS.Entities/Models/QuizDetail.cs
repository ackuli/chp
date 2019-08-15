using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class QuizDetail
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public int Score { get; set; }
        public Nullable<int> GivenAnswerChoiceId { get; set; }
        public int CorrectAnswerChoiceId { get; set; }
        public virtual AnswerChoice AnswerChoice { get; set; }
        public virtual AnswerChoice AnswerChoice1 { get; set; }
        public virtual Question Question { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
