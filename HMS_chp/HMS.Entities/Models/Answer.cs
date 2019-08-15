using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public string WhyAnswerCorrect { get; set; }
        public bool IsActive { get; set; }
    }
}
