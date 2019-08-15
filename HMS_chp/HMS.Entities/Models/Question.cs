using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Question
    {
        public Question()
        {
            this.AnswerChoices = new List<AnswerChoice>();
            this.QuestionDetails = new List<QuestionDetail>();
            this.QuizQuestionAnswers = new List<QuizQuestionAnswer>();
            this.QuizDetails = new List<QuizDetail>();
        }

        public int QuestionId { get; set; }

        public int? QuestionSLNo { get; set; }
        public string QuestionText { get; set; }
        public Nullable<int> QuizId { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<AnswerChoice> AnswerChoices { get; set; }
        public virtual ICollection<QuestionDetail> QuestionDetails { get; set; }
        public virtual ICollection<QuizQuestionAnswer> QuizQuestionAnswers { get; set; }
        public virtual ICollection<QuizDetail> QuizDetails { get; set; }
    }
}
