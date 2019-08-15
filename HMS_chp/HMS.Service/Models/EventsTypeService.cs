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
   public interface IEventsTypesService
   {
       EventsType Find(params object[] keyValues);
       void Insert(EventsType entity);
       void Update(EventsType entity);
       void Delete(object id);
       void Delete(EventsType entity);
       IEnumerable<EventsType> GetAllEventsType();
       IEnumerable<EventsType> GetActiveEventsType(bool IsActive);
       EventsType GetEventsTypeById(int Id);     
     
   }
   public class EventsTypeService : Service<EventsType>, IEventsTypesService
   {
       private readonly IRepositoryAsync<EventsType> _repository;
       private readonly IQuestionTypeService _iQuestionTypeServicee;
       public EventsTypeService(

             IRepositoryAsync<EventsType> repository
           , IQuestionTypeService iQuestionTypeServicee
           )
           : base(repository)
       {
           _repository = repository;
           _iQuestionTypeServicee = iQuestionTypeServicee;
       }
       public IEnumerable<EventsType> GetAllEventsType()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<EventsType> GetActiveEventsType(bool IsActive)
       {
           return _repository
                  .Query(x=>x.IsActive==IsActive)
                  .Select();
       }

       public EventsType GetEventsTypeById(int Id)
       {
           return _repository
               .Query(x => x.EventsTypeId == Id)
               .Select().FirstOrDefault();
       }
      
   }
}
