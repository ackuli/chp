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
   public interface IDurationsService
   {
       Duration Find(params object[] keyValues);
       void Insert(Duration entity);
       void Update(Duration entity);
       void Delete(object id);
       void Delete(Duration entity);
       IEnumerable<Duration> GetAllDuration();
       IEnumerable<Duration> GetVisibleDuration(bool IsVisible);
       Duration GetDurationById(int Id);
       Duration newDuration();
       // Duration Add(Duration project);
   }
   public class DurationService : Service<Duration>, IDurationsService
   {
       private readonly IRepositoryAsync<Duration> _repository;
       private readonly IQuestionTypeService _iQuestionTypeServicee;
       public DurationService(

             IRepositoryAsync<Duration> repository
           , IQuestionTypeService iQuestionTypeServicee
           )
           : base(repository)
       {
           _repository = repository;
           _iQuestionTypeServicee = iQuestionTypeServicee;
       }
       public IEnumerable<Duration> GetAllDuration()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<Duration> GetVisibleDuration(bool IsVisible)
       {
           return _repository
                  .Query()
                  .Select();
       }

       public Duration GetDurationById(int Id)
       {
           return _repository
               .Query(x => x.DurationId == Id)
               .Select().FirstOrDefault();
       }
       public Duration newDuration()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
           _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
           {
               lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
           });

           Duration objDuration = new Duration();
           // objDuration.kvpQuestionType = lstTypes;
           return objDuration;
       }
   }
}
