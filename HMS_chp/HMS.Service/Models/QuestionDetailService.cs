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


    public interface IQuestionDetailsService
    {
        QuestionDetail Find(params object[] keyValues);
        void Insert(QuestionDetail entity);
        void Update(QuestionDetail entity);
        void Delete(object id);
        void Delete(QuestionDetail entity);
        IEnumerable<QuestionDetail> GetAllQuestionDetail();
        IEnumerable<QuestionDetail> GetActiveQuestionDetail(bool IsActive);
        QuestionDetail GetQuestionDetailById(int Id);
       IEnumerable<QuestionDetail> GetQuestionDetailByQuestionId(int questionId);

    }
    public class QuestionDetailService : Service<QuestionDetail>, IQuestionDetailsService
    {
        private readonly IRepositoryAsync<QuestionDetail> _repository;

        public QuestionDetailService(

              IRepositoryAsync<QuestionDetail> repository

            )
            : base(repository)
        {
            _repository = repository;

        }
        public IEnumerable<QuestionDetail> GetAllQuestionDetail()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<QuestionDetail> GetActiveQuestionDetail(bool IsActive)
        {
            return _repository
                   .Query(x => x.IsActive == IsActive)
                   .Select();
        }

        public QuestionDetail GetQuestionDetailById(int Id)
        {
            return _repository
                .Query(x => x.Id == Id)
                .Select().FirstOrDefault();
        }
        public IEnumerable<QuestionDetail> GetQuestionDetailByQuestionId(int questionId)
        {
            return _repository.Query(x => x.QuestionId == questionId)
                .Include(x=>x.Question).Select();
        }
    }
}
