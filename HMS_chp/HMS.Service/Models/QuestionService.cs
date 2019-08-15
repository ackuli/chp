using HMS.Entities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Models
{

    public interface IQuestionsService
    {
        Question Find(params object[] keyValues);
        void Insert(Question entity);
        void Update(Question entity);
        void Delete(object id);
        void Delete(Question entity);
        IEnumerable<Question> GetAllQuestion();
        IEnumerable<Question> GetActiveQuestion(bool IsActive);
        Question GetQuestionById(int Id);
        string NextQuizRandom(int quizId, int questionId);

    }
    public class QuestionService : Service<Question>, IQuestionsService
    {
        private readonly IRepositoryAsync<Question> _repository;
        private readonly IStoredProcedures _iStoredProcedures;

        public QuestionService(

              IRepositoryAsync<Question> repository
            , IStoredProcedures iStoredProcedures

            )
            : base(repository)
        {
            _repository = repository;
            _iStoredProcedures = iStoredProcedures;

        }
        public IEnumerable<Question> GetAllQuestion()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<Question> GetActiveQuestion(bool IsActive)
        {
            return _repository
                   .Query(x => x.IsActive == IsActive)
                   .Include(x => x.AnswerChoices)
                   .Select();
        }

        public Question GetQuestionById(int Id)
        {
            return _repository
                .Query(x => x.QuestionId == Id)
                .Include(x => x.AnswerChoices)
                .Include(x => x.QuizQuestionAnswers)
                 .Include(x => x.QuestionDetails)
                .Select().SingleOrDefault();
        }
        public string NextQuizRandom(int quizId, int questionId)
        {
            return _iStoredProcedures.NextQuizRandom(quizId,questionId);
        }

    }
}
