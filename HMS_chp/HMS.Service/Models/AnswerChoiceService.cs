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

    public interface IAnswerChoicesService
    {
        AnswerChoice Find(params object[] keyValues);
        void Insert(AnswerChoice entity);
        void Update(AnswerChoice entity);
        void Delete(object id);
        void Delete(AnswerChoice entity);
        IEnumerable<AnswerChoice> GetAllAnswerChoice();
        IEnumerable<AnswerChoice> GetActiveAnswerChoice(bool IsActive);
        AnswerChoice GetAnswerChoiceById(int Id);
        AnswerChoice GetAnswerChoice(int questionId, string choiceText, bool IsActive);
        IEnumerable<AnswerChoice> GetAnswerChoice(int questionId);

    }
    public class AnswerChoiceService : Service<AnswerChoice>, IAnswerChoicesService
    {
        private readonly IRepositoryAsync<AnswerChoice> _repository;

        public AnswerChoiceService(

              IRepositoryAsync<AnswerChoice> repository

            )
            : base(repository)
        {
            _repository = repository;

        }
        public IEnumerable<AnswerChoice> GetAllAnswerChoice()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<AnswerChoice> GetActiveAnswerChoice(bool IsActive)
        {
            return _repository
                   .Query(x => x.IsActive == IsActive)
                   .Select();
        }

        public AnswerChoice GetAnswerChoiceById(int Id)
        {
            return _repository
                .Query(x => x.AnswerChoiceId == Id)
                .Select().FirstOrDefault();
        }
        public AnswerChoice GetAnswerChoice(int questionId, string choiceText, bool IsActive)
        {

            return _repository.Query(x => x.QuestionId == questionId && x.Choices == choiceText && x.IsActive == IsActive).Select().SingleOrDefault();
        }
        public IEnumerable<AnswerChoice> GetAnswerChoice(int questionId)
        {

            return _repository.Query(x => x.QuestionId == questionId)
                .Include(x=>x.Question).Select();
        }

    }
}
