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
      
    public interface IRightsssService
    {
        Rightss Find(params object[] keyValues);
        void Insert(Rightss entity);
        void Update(Rightss entity);
        void Delete(object id);
        void Delete(Rightss entity);
        IEnumerable<Rightss> GetAllRightss();
        IEnumerable<Rightss> GetActiveRightss(bool IsActive);
        Rightss GetRightssById(int Id);
        Rightss newRightss();
        // Rightss Add(Rightss project);
    }
    public class RightssService : Service<Rightss>, IRightsssService
    {
        private readonly IRepositoryAsync<Rightss> _repository;
        private readonly IQuestionTypeService _iQuestionTypeServicee;
        public RightssService(

              IRepositoryAsync<Rightss> repository
            , IQuestionTypeService iQuestionTypeServicee
            )
            : base(repository)
        {
            _repository = repository;
            _iQuestionTypeServicee = iQuestionTypeServicee;
        }
        public IEnumerable<Rightss> GetAllRightss()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<Rightss> GetActiveRightss(bool IsActive)
        {
            return _repository
                   .Query()
                   .Select();
        }

        public Rightss GetRightssById(int Id)
        {
            return _repository
                .Query(x => x.RightsId == Id)
                .Select().FirstOrDefault();
        }
        public Rightss newRightss()
        {
            var lstTypes = new List<KeyValuePair<int, string>>();
            _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
            {
                lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
            });

            Rightss objRightss = new Rightss();
            // objRightss.kvpQuestionType = lstTypes;
            return objRightss;
        }
    }
}
