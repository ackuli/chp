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
    public interface IQuestionAnswersService
    {
        QuestionAnswer Find(params object[] keyValues);
        void Insert(QuestionAnswer entity);
        void Update(QuestionAnswer entity);
        void Delete(object id);
        void Delete(QuestionAnswer entity);
        IEnumerable<QuestionAnswer> GetAllQuestionAnswer();
        IEnumerable<QuestionAnswer> GetVisibleQuestionAnswer(bool IsVisible);
        QuestionAnswer GetQuestionAnswerById(int Id);
        QuestionAnswer newQuestionAnswer();
        IEnumerable<QuestionAnswer> GetQuestionAnswerByCategory(int QuestionType, string keyword);
        IEnumerable<QuestionAnswer> GetQuestionAnswerByKeyWords(string keyword);
        IEnumerable<QuestionAnswer> GetFrequentAskQuestionAnswer(bool IsVisible, bool IsFrequentAsk);
      
    }
    public class QuestionAnswerService : Service<QuestionAnswer>, IQuestionAnswersService
    {
        private readonly IRepositoryAsync<QuestionAnswer> _repository;
        private readonly IQuestionTypeService _iQuestionTypeServicee;
        public QuestionAnswerService(

              IRepositoryAsync<QuestionAnswer> repository
            , IQuestionTypeService iQuestionTypeServicee
            )
            : base(repository)
        {
            _repository = repository;
            _iQuestionTypeServicee = iQuestionTypeServicee;
        }
        public IEnumerable<QuestionAnswer> GetAllQuestionAnswer()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<QuestionAnswer> GetVisibleQuestionAnswer(bool IsVisible)
        {
            return _repository
                   .Query(x => x.IsVisible == IsVisible && x.IsFrequentAsk==false)
                   .Select();
        }
        public IEnumerable<QuestionAnswer> GetFrequentAskQuestionAnswer(bool IsVisible,bool IsFrequentAsk)
        {
            return _repository
                   .Query(x => x.IsVisible == IsVisible && x.IsFrequentAsk == IsFrequentAsk)
                   .Select();
        }
        public QuestionAnswer GetQuestionAnswerById(int Id)
        {
            return _repository
                .Query(x => x.Id == Id)
                .Select().FirstOrDefault();
        }
        public QuestionAnswer newQuestionAnswer()
        {
            var lstTypes = new List<KeyValuePair<int, string>>();
           _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
            {
                lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
            });

            QuestionAnswer objQuestionAnswer = new QuestionAnswer();
            objQuestionAnswer.kvpQuestionType = lstTypes;
            return objQuestionAnswer;
        }
        public IEnumerable<QuestionAnswer> GetQuestionAnswerByCategory(int QuestionType,string keyword)
        {
            //if (keyword==null)
            //{
            //    return _repository
            //    .Query(x => x.TypeId == QuestionType || x.KeyWords.Contains(keyword) && x.Answer!=null)
            //    .Select();             
            //}
            //else
            //{
            //    return _repository
            //    .Query(x => x.TypeId == QuestionType && x.Question.Contains(keyword) && x.Answer != null) 
            //    .Select();             
            //}
            return _repository
                .Query(x => x.TypeId == QuestionType && x.Question != null)
                .Select();   
            
        }
        public IEnumerable<QuestionAnswer> GetQuestionAnswerByKeyWords(string keyword)
        {
           
                return _repository
                .Query(x => x.Question.Contains(keyword) && x.Question != null) 
                .Select();             
        }
        
    }
}
