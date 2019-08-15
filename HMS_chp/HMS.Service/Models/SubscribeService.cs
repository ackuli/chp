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
  
   public interface ISubscribesService
   {
       Subscribe Find(params object[] keyValues);
       void Insert(Subscribe entity);
       void Update(Subscribe entity);
       void Delete(object id);
       void Delete(Subscribe entity);
       IEnumerable<Subscribe> GetAllSubscribe();
       IEnumerable<Subscribe> GetActiveSubscribe(bool IsActive);
       Subscribe GetSubscribeById(int Id);
       Subscribe newSubscribe();
       // Subscribe Add(Subscribe project);
   }
   public class SubscribeService : Service<Subscribe>, ISubscribesService
   {
       private readonly IRepositoryAsync<Subscribe> _repository;
       private readonly IQuestionTypeService _iQuestionTypeServicee;
       public SubscribeService(

             IRepositoryAsync<Subscribe> repository
           , IQuestionTypeService iQuestionTypeServicee
           )
           : base(repository)
       {
           _repository = repository;
           _iQuestionTypeServicee = iQuestionTypeServicee;
       }
       public IEnumerable<Subscribe> GetAllSubscribe()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<Subscribe> GetActiveSubscribe(bool IsActive)
       {
           return _repository
                  .Query()
                  .Select();
       }

       public Subscribe GetSubscribeById(int Id)
       {
           return _repository
               .Query(x => x.Id == Id)
               .Select().FirstOrDefault();
       }
       public Subscribe newSubscribe()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
           _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
           {
               lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
           });

           Subscribe objSubscribe = new Subscribe();
           // objSubscribe.kvpQuestionType = lstTypes;
           return objSubscribe;
       }
   }
}
