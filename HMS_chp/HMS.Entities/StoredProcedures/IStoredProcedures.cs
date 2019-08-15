using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    public interface IStoredProcedures
    {
        IEnumerable<Content> GetContent(string FREETEXT);
        string NextQuizRandom(int quizId, int questionId);
    }
}
