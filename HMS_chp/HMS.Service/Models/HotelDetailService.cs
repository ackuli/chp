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


 public interface IHotelDetailsService
 {
     HotelDetail Find(params object[] keyValues);
     void Insert(HotelDetail entity);
     void Update(HotelDetail entity);
     void Delete(object id);
     void Delete(HotelDetail entity);
     IEnumerable<HotelDetail> GetAllHotelDetail();
     IEnumerable<HotelDetail> GetActiveHotelDetail(bool IsActive);
     HotelDetail GetHotelDetailById(int Id);
     HotelDetail newHotelDetail();
     // HotelDetail Add(HotelDetail project);
 }
 public class HotelDetailService : Service<HotelDetail>, IHotelDetailsService
 {
     private readonly IRepositoryAsync<HotelDetail> _repository;
     private readonly IQuestionTypeService _iQuestionTypeServicee;
     public HotelDetailService(

           IRepositoryAsync<HotelDetail> repository
         , IQuestionTypeService iQuestionTypeServicee
         )
         : base(repository)
     {
         _repository = repository;
         _iQuestionTypeServicee = iQuestionTypeServicee;
     }
     public IEnumerable<HotelDetail> GetAllHotelDetail()
     {
         return _repository.Query().Select();
     }
     public IEnumerable<HotelDetail> GetActiveHotelDetail(bool IsActive)
     {
         return _repository
                .Query()
                .Select();
     }

     public HotelDetail GetHotelDetailById(int Id)
     {
         return _repository
             .Query(x => x.Id == Id)
             .Select().FirstOrDefault();
     }
     public HotelDetail newHotelDetail()
     {
         var lstTypes = new List<KeyValuePair<int, string>>();
         _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
         {
             lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
         });

         HotelDetail objHotelDetail = new HotelDetail();
         // objHotelDetail.kvpQuestionType = lstTypes;
         return objHotelDetail;
     }
 }
}
