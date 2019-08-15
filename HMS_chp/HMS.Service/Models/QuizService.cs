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
  
    public interface IQuizsService
    {
        Quiz Find(params object[] keyValues);
        void Insert(Quiz entity);
        void Update(Quiz entity);
        void Delete(object id);
        void Delete(Quiz entity);
        IEnumerable<Quiz> GetAllQuiz();
        IEnumerable<Quiz> GetActiveQuiz(bool IsActive);
        Quiz GetQuizById(int Id);

    }
    public class QuizService : Service<Quiz>, IQuizsService
    {
        private readonly IRepositoryAsync<Quiz> _repository;

        public QuizService(

              IRepositoryAsync<Quiz> repository

            )
            : base(repository)
        {
            _repository = repository;

        }
        public IEnumerable<Quiz> GetAllQuiz()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<Quiz> GetActiveQuiz(bool IsActive)
        {
            return _repository
                   .Query(x => x.IsActive == IsActive)
                   .Select();
        }

        public Quiz GetQuizById(int Id)
        {
            return _repository
                .Query(x => x.QuizId == Id)
                .Select().FirstOrDefault();
        }

    }
}
