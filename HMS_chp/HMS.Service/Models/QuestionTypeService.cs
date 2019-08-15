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
   public interface  IQuestionTypeService
    {
       QuestionType Find(params object[] keyValues);
        void Insert(QuestionType entity);
        void Update(QuestionType entity);
        void Delete(object id);
        void Delete(QuestionType entity);
       IEnumerable<QuestionType> GetAllQuestionType();

       QuestionType GetQuestionTypeId(int id);
       List<KeyValuePair<int, string>> KVPGetQuestionType();
    }
    public class QuestionTypeService:Service<QuestionType>,IQuestionTypeService
    {
        private readonly IRepositoryAsync<QuestionType> _repository;
        public QuestionTypeService(IRepositoryAsync<QuestionType> repository)
            : base(repository)
        {
            _repository = repository;
        }
        public IEnumerable<QuestionType> GetAllQuestionType()
        {
            return _repository.Query().Select();
        }

        public QuestionType GetQuestionTypeId(int Id)
        {
            return _repository
                .Query(x => x.Id == Id)
                .Select().FirstOrDefault();
        }
        public List<KeyValuePair<int, string>> KVPGetQuestionType()
        {
            var lstTypes = new List<KeyValuePair<int, string>>();
            _repository.Query().Select().ToList().ForEach(delegate(QuestionType item)
            {
                lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
            });

            return lstTypes;
        }
    }
}
