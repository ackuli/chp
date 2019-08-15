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
  public interface IHotelsService
  {
      Hotel Find(params object[] keyValues);
      void Insert(Hotel entity);
      void Update(Hotel entity);
      void Delete(object id);
      void Delete(Hotel entity);
      IEnumerable<Hotel> GetAllHotel();
      IEnumerable<Hotel> GetActiveHotel(bool IsActive);
      Hotel GetHotelById(int Id);
      Hotel newHotel();
      // Hotel Add(Hotel project);
  }
  public class HotelService : Service<Hotel>, IHotelsService
  {
      private readonly IRepositoryAsync<Hotel> _repository;
      private readonly IQuestionTypeService _iQuestionTypeServicee;
      public HotelService(

            IRepositoryAsync<Hotel> repository
          , IQuestionTypeService iQuestionTypeServicee
          )
          : base(repository)
      {
          _repository = repository;
          _iQuestionTypeServicee = iQuestionTypeServicee;
      }
      public IEnumerable<Hotel> GetAllHotel()
      {
          return _repository.Query().Select();
      }
      public IEnumerable<Hotel> GetActiveHotel(bool IsActive)
      {
          return _repository
                 .Query()
                 .Select();
      }

      public Hotel GetHotelById(int Id)
      {
          return _repository
              .Query(x => x.Id == Id)
              .Select().FirstOrDefault();
      }
      public Hotel newHotel()
      {
          var lstTypes = new List<KeyValuePair<int, string>>();
          _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
          {
              lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
          });

          Hotel objHotel = new Hotel();
          // objHotel.kvpQuestionType = lstTypes;
          return objHotel;
      }
  }
}
