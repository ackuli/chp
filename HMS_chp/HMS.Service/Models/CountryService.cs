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
   public interface ICountrysService
   {
       Country Find(params object[] keyValues);
       void Insert(Country entity);
       void Update(Country entity);
       void Delete(object id);
       void Delete(Country entity);
       IEnumerable<Country> GetAllCountry();
       IEnumerable<Country> GetVisibleCountry(bool IsVisible);
       Country GetCountryById(int Id);
      
   }
   public class CountryService : Service<Country>, ICountrysService
   {
       private readonly IRepositoryAsync<Country> _repository;
       private readonly IQuestionTypeService _iQuestionTypeServicee;
       public CountryService(

             IRepositoryAsync<Country> repository
           , IQuestionTypeService iQuestionTypeServicee
           )
           : base(repository)
       {
           _repository = repository;
           _iQuestionTypeServicee = iQuestionTypeServicee;
       }
       public IEnumerable<Country> GetAllCountry()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<Country> GetVisibleCountry(bool IsVisible)
       {
           return _repository
                  .Query()
                  .Select();
       }

       public Country GetCountryById(int Id)
       {
           return _repository
               .Query(x => x.CountryId == Id)
               .Select().FirstOrDefault();
       }
     
   }
}
