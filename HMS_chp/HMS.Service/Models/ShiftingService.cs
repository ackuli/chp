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
    public interface  IShiftingService
    {
        Shifting Find(params object[] keyValues);
        void Insert(Shifting entity);
        void Update(Shifting entity);
        void Delete(object id);
        void Delete(Shifting entity);
        IEnumerable<Shifting> GetAllShifting();
        IEnumerable<Shifting> GetVisibleShifting(bool IsVisible);
        Shifting GetShiftingById(int Id);
        Shifting newShifting();
    }
    public class ShiftingService : Service<Shifting>, IShiftingService
    {
         private readonly IRepositoryAsync<Shifting> _repository;
    
       public ShiftingService(

             IRepositoryAsync<Shifting> repository
          
           )
           : base(repository)
       {
           _repository = repository;
        
       }
       public IEnumerable<Shifting> GetAllShifting()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<Shifting> GetVisibleShifting(bool IsVisible)
       {
           return _repository
                  .Query()
                  .Select();
       }

       public Shifting GetShiftingById(int Id)
       {
           return _repository
               .Query(x => x.ShiftingId == Id)
               .Select().FirstOrDefault();
       }
       public Shifting newShifting()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
          
           Shifting objShifting = new Shifting();          
           return objShifting;
       }
    }
}
