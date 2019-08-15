using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            this.QuestionAnswers = new List<QuestionAnswer>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string SetDate { get; set; }
        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
