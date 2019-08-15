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

    public interface IQuizQuestionAnswersService
    {
        QuizQuestionAnswer Find(params object[] keyValues);
        void Insert(QuizQuestionAnswer entity);
        void Update(QuizQuestionAnswer entity);
        void Delete(object id);
        void Delete(QuizQuestionAnswer entity);
        IEnumerable<QuizQuestionAnswer> GetAllQuizQuestionAnswer();
        IEnumerable<QuizQuestionAnswer> GetActiveQuizQuestionAnswer(bool IsActive);
        QuizQuestionAnswer GetQuizQuestionAnswerById(int Id);
       IEnumerable<QuizQuestionAnswer> GetQuizQuestionAnswerByQuestionId(int questionId);

       QuizQuestionAnswer newQuizQuestionAnswer(int questionId);
       
    }
    public class QuizQuestionAnswerService : Service<QuizQuestionAnswer>, IQuizQuestionAnswersService
    {
        private readonly IRepositoryAsync<QuizQuestionAnswer> _repository;
        private readonly IAnswerChoicesService _IAnswerChoicesService;
        public QuizQuestionAnswerService(

              IRepositoryAsync<QuizQuestionAnswer> repository, IAnswerChoicesService IAnswerChoicesService

            )
            : base(repository)
        {
            _repository = repository;
            _IAnswerChoicesService = IAnswerChoicesService;
           
        }
        public IEnumerable<QuizQuestionAnswer> GetAllQuizQuestionAnswer()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<QuizQuestionAnswer> GetActiveQuizQuestionAnswer(bool IsActive)
        {
            return _repository
                   .Query(x => x.IsActive == IsActive)
                   .Select();
        }

        public QuizQuestionAnswer GetQuizQuestionAnswerById(int Id)
        {
            return _repository
                .Query(x => x.Id == Id)
                .Select().FirstOrDefault();
        }
        public IEnumerable<QuizQuestionAnswer> GetQuizQuestionAnswerByQuestionId(int questionId)
        {
            return _repository.Query(x => x.QuestionId == questionId).Include(x=>x.AnswerChoice)
                .Include(x=>x.Question).Select();
        }

        public QuizQuestionAnswer newQuizQuestionAnswer(int questionId)
        {
            var lstAnswerChoice = new List<KeyValuePair<int, string>>();
            var objquizQuestionAnswer = new QuizQuestionAnswer();
            _IAnswerChoicesService.GetAnswerChoice(questionId).Where(x => x.IsAnswer == true).ToList().ForEach(delegate(AnswerChoice item)
            {
                lstAnswerChoice.Add(new KeyValuePair<int, string>(item.AnswerChoiceId, item.Choices));
            });
            objquizQuestionAnswer.kvpAnswerChoice = lstAnswerChoice;
            return objquizQuestionAnswer;

        }
    }
}
