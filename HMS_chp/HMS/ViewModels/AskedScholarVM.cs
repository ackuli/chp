using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Models;
using HMS.Entities.Models;

namespace HMS.ViewModels
{
    public class AskedScholarVm
    {
        public List<QuestionAnswer> RecentQuestionAnswersList { get; set; }
        public List<QuestionAnswer> FAQ { get; set; }
    }
}