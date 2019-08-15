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
  public interface ICurrencyTypesService
  {
      CurrencyType Find(params object[] keyValues);
      void Insert(CurrencyType entity);
      void Update(CurrencyType entity);
      void Delete(object id);
      void Delete(CurrencyType entity);
      IEnumerable<CurrencyType> GetAllCurrencyType();
      IEnumerable<CurrencyType> GetVisibleCurrencyType(bool IsVisible);
      CurrencyType GetCurrencyTypeById(int Id);

  }
  public class CurrencyTypeService : Service<CurrencyType>, ICurrencyTypesService
  {
      private readonly IRepositoryAsync<CurrencyType> _repository;
      private readonly IQuestionTypeService _iQuestionTypeServicee;
      public CurrencyTypeService(

            IRepositoryAsync<CurrencyType> repository
          , IQuestionTypeService iQuestionTypeServicee
          )
          : base(repository)
      {
          _repository = repository;
          _iQuestionTypeServicee = iQuestionTypeServicee;
      }
      public IEnumerable<CurrencyType> GetAllCurrencyType()
      {
          return _repository.Query().Select();
      }
      public IEnumerable<CurrencyType> GetVisibleCurrencyType(bool IsVisible)
      {
          return _repository
                 .Query()
                 .Select();
      }

      public CurrencyType GetCurrencyTypeById(int Id)
      {
          return _repository
              .Query(x => x.CurrencyTypeId == Id)
              .Select().FirstOrDefault();
      }

  }
}
