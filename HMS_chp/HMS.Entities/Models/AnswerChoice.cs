using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class AnswerChoice
    {
        public AnswerChoice()
        {
            this.QuizQuestionAnswers = new List<QuizQuestionAnswer>();
            this.QuizDetails = new List<QuizDetail>();
            this.QuizDetails1 = new List<QuizDetail>();
        }

        public int AnswerChoiceId { get; set; }
        public string Choices { get; set; }
        public int QuestionId { get; set; }
        public bool IsAnswer { get; set; }
        public string WhyAnswerCorrect { get; set; }
        public bool IsActive { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<QuizQuestionAnswer> QuizQuestionAnswers { get; set; }
        public virtual ICollection<QuizDetail> QuizDetails { get; set; }
        public virtual ICollection<QuizDetail> QuizDetails1 { get; set; }
    }
}
