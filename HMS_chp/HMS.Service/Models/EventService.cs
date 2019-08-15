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
  
   public interface IEventService
   {
        Event Find(params object[] keyValues);
       void Insert( Event entity);
       void Update( Event entity);
       void Delete(object id);
       void Delete( Event entity);
       IEnumerable< Event> GetAllEvent();
       IEnumerable< Event> GetActivEvent(bool IsActive);
       IEnumerable<Event> GetDefaultEvent(bool IsDefault,bool IsActive);
       IEnumerable<Event> GetArchiveEvent(bool IsActive);
        Event GetEventById(int Id);
       Event newEvent();
       // Event Add(Event project);
   }
   public class EventService : Service<Event>, IEventService
   {
       private readonly IRepositoryAsync< Event> _repository;
       private readonly IEventsTypesService _iEventsTypesService;
       public  EventService(

             IRepositoryAsync<Event> repository
           , IEventsTypesService iEventsTypesService
           )
           : base(repository)
       {
           _repository = repository;
           _iEventsTypesService = iEventsTypesService;
       }
       public IEnumerable<Event> GetAllEvent()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<Event> GetActivEvent(bool IsActive)
       {
           return _repository
                  .Query(x => x.IsVisible == IsActive && x.IsArchive==false)
                  .Select().OrderByDescending(x => x.EventsDate);
       }
       public  IEnumerable<Event> GetDefaultEvent(bool IsDefault, bool IsActive)
       {
           return _repository
                  .Query(x => x.IsDefault == IsDefault && x.IsVisible == IsActive)
                  .Select();
       }
      
       public IEnumerable<Event> GetArchiveEvent(bool IsArchive)
       {
           return _repository
                  .Query(x => x.IsVisible == true && x.IsArchive == IsArchive)
                  .Select().OrderByDescending(x => x.EventsDate);
       }


       public Event GetEventById(int Id)
       {
           return _repository
               .Query(x => x.EventsId == Id)
               .Include(x=>x.EventsType)
               .Select().FirstOrDefault();
       }
       public Event newEvent()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
           _iEventsTypesService.GetActiveEventsType(true).ToList().ForEach(delegate(EventsType item)
           {
               lstTypes.Add(new KeyValuePair<int, string>(item.EventsTypeId, item.EventsTypeName));
           });

           Event objEvent = new Event();
           objEvent.kvpEventType = lstTypes;
           return objEvent;
       }
   }
}
