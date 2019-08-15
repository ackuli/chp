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


    public interface IAnswersService
    {
        Answer Find(params object[] keyValues);
        void Insert(Answer entity);
        void Update(Answer entity);
        void Delete(object id);
        void Delete(Answer entity);
        IEnumerable<Answer> GetAllAnswer();
        IEnumerable<Answer> GetActiveAnswer(bool IsActive);
        Answer GetAnswerById(int Id);

    }
    public class AnswerService : Service<Answer>, IAnswersService
    {
        private readonly IRepositoryAsync<Answer> _repository;

        public AnswerService(

              IRepositoryAsync<Answer> repository

            )
            : base(repository)
        {
            _repository = repository;

        }
        public IEnumerable<Answer> GetAllAnswer()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<Answer> GetActiveAnswer(bool IsActive)
        {
            return _repository
                   .Query(x => x.IsActive == IsActive)
                   .Select();
        }

        public Answer GetAnswerById(int Id)
        {
            return _repository
                .Query(x => x.AnswerId == Id)
                .Select().FirstOrDefault();
        }

    }
}
