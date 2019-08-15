using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            this.QuizDetails = new List<QuizDetail>();
        }

        public int QuizId { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.TimeSpan> Duration { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public int? PreQuizRefId { get; set; }
        public int Score { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<QuizDetail> QuizDetails { get; set; }
    }
}
