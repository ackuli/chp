using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class QuestionDetail
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string QuestionDetailsText { get; set; }
        public bool IsActive { get; set; }
        public virtual Question Question { get; set; }
    }
}
