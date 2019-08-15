using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class QuestionAnswer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string ScoloarId { get; set; }
        public int TypeId { get; set; }
        public int Count { get; set; }
        public string EmailId { get; set; }
        public bool IsVisible { get; set; }
        public Nullable<System.DateTime> AnswerDate { get; set; }
        public Nullable<System.DateTime> SetDate { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public bool IsSelfInitiative { get; set; }
        public bool IsFrequentAsk { get; set; }
        public string KeyWords { get; set; }
        public virtual QuestionType QuestionType { get; set; }
    }
}
