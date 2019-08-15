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

    public interface IQuizDetailsService
    {
        QuizDetail Find(params object[] keyValues);
        void Insert(QuizDetail entity);
        void Update(QuizDetail entity);
        void Delete(object id);
        void Delete(QuizDetail entity);
        IEnumerable<QuizDetail> GetAllQuizDetail();
        IEnumerable<QuizDetail> GetActiveQuizDetail(bool IsActive);
        QuizDetail GetQuizDetailById(int Id);
        IEnumerable<QuizDetail> GetQuizDetail(int quizId);
        IEnumerable<QuizDetail> checkyouranswer(int quizId);
    }
    public class QuizDetailService : Service<QuizDetail>, IQuizDetailsService
    {
        private readonly IRepositoryAsync<QuizDetail> _repository;

        public QuizDetailService(

              IRepositoryAsync<QuizDetail> repository

            )
            : base(repository)
        {
            _repository = repository;

        }
        public IEnumerable<QuizDetail> GetAllQuizDetail()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<QuizDetail> GetActiveQuizDetail(bool IsActive)
        {
            return _repository
                   .Query()
                   .Include(x => x.AnswerChoice)
                   .Select();
        }

        public QuizDetail GetQuizDetailById(int Id)
        {
            return _repository
                .Query(x => x.Id == Id)
                .Include(x => x.AnswerChoice)
                .Select().FirstOrDefault();
        }
        public IEnumerable<QuizDetail> GetQuizDetail(int quizId)
        {
            return _repository.Query(x => x.QuizId == quizId).Select();
        }
        public IEnumerable<QuizDetail> checkyouranswer(int quizId)
        {
            return _repository.Query(x => x.QuizId == quizId)
                .Include(x => x.AnswerChoice)
                .Include(x => x.AnswerChoice1)
                .Include(x => x.Question)
                 .Include(x => x.Question.QuestionDetails)
                .Include(x => x.Question.AnswerChoices)
               .Select();
        }
    }
}
