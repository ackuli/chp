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
  public interface IPeoplePerRoomsService
  {
      PeoplePerRoom Find(params object[] keyValues);
      void Insert(PeoplePerRoom entity);
      void Update(PeoplePerRoom entity);
      void Delete(object id);
      void Delete(PeoplePerRoom entity);
      IEnumerable<PeoplePerRoom> GetAllPeoplePerRoom();
      IEnumerable<PeoplePerRoom> GetActivePeoplePerRoom(bool IsActive);
      PeoplePerRoom GetPeoplePerRoomById(int Id);
      PeoplePerRoom newPeoplePerRoom();
      // PeoplePerRoom Add(PeoplePerRoom project);
  }
  public class PeoplePerRoomService : Service<PeoplePerRoom>, IPeoplePerRoomsService
  {
      private readonly IRepositoryAsync<PeoplePerRoom> _repository;
      private readonly IQuestionTypeService _iQuestionTypeServicee;
      public PeoplePerRoomService(

            IRepositoryAsync<PeoplePerRoom> repository
          , IQuestionTypeService iQuestionTypeServicee
          )
          : base(repository)
      {
          _repository = repository;
          _iQuestionTypeServicee = iQuestionTypeServicee;
      }
      public IEnumerable<PeoplePerRoom> GetAllPeoplePerRoom()
      {
          return _repository.Query().Select();
      }
      public IEnumerable<PeoplePerRoom> GetActivePeoplePerRoom(bool IsActive)
      {
          return _repository
                 .Query()
                 .Select();
      }

      public PeoplePerRoom GetPeoplePerRoomById(int Id)
      {
          return _repository
              .Query(x => x.Id == Id)
              .Select().FirstOrDefault();
      }
      public PeoplePerRoom newPeoplePerRoom()
      {
          var lstTypes = new List<KeyValuePair<int, string>>();
          _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
          {
              lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
          });

          PeoplePerRoom objPeoplePerRoom = new PeoplePerRoom();
          // objPeoplePerRoom.kvpQuestionType = lstTypes;
          return objPeoplePerRoom;
      }
  }
}
