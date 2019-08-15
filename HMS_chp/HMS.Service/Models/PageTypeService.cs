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
  public interface IPageTypesService
  {
      PageType Find(params object[] keyValues);
      void Insert(PageType entity);
      void Update(PageType entity);
      void Delete(object id);
      void Delete(PageType entity);
      IEnumerable<PageType> GetAllPageType();
      IEnumerable<PageType> GetActivePageType(bool IsActive);
      PageType GetPageTypeById(int Id);
  }
  public class PageTypeService : Service<PageType>, IPageTypesService
  {
      private readonly IRepositoryAsync<PageType> _repository;
    
      public PageTypeService(

            IRepositoryAsync<PageType> repository        
          )
          : base(repository)
      {
          _repository = repository;
      }
      public IEnumerable<PageType> GetAllPageType()
      {
          return _repository.Query().Select();
      }
      public IEnumerable<PageType> GetActivePageType(bool IsActive)
      {
          return _repository
                 .Query()
                 .Select();
      }
      public PageType GetPageTypeById(int Id)
      {
          return _repository
              .Query(x => x.Id == Id)
              .Select().FirstOrDefault();
      }
      
  }
}
