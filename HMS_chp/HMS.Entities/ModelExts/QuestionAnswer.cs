using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HMS.Entities.Models
{
     [MetadataType(typeof(QuestionAnswerMetadata))]
    public partial class QuestionAnswer : Entity
    {
        public List<KeyValuePair<int, string>> kvpQuestionType { get; set; }
        public List<QuestionAnswer> RecentQuestionAnswersList { get; set; }
        public IEnumerable<QuestionAnswer> CategoryWiseQuestionAnswersList { get; set; }
        public List<QuestionAnswer> FAQ { get; set; }
    }
}
