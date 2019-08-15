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
  
  public interface IPackageSourcesService
  {
      PackageSource Find(params object[] keyValues);
      void Insert(PackageSource entity);
      void Update(PackageSource entity);
      void Delete(object id);
      void Delete(PackageSource entity);
      IEnumerable<PackageSource> GetAllPackageSource();
      IEnumerable<PackageSource> GetActivePackageSource(bool IsActive);
      PackageSource GetPackageSourceById(int Id);
      PackageSource newPackageSource();
      // PackageSource Add(PackageSource project);
  }
  public class PackageSourceService : Service<PackageSource>, IPackageSourcesService
  {
      private readonly IRepositoryAsync<PackageSource> _repository;
      private readonly IQuestionTypeService _iQuestionTypeServicee;
      public PackageSourceService(

            IRepositoryAsync<PackageSource> repository
          , IQuestionTypeService iQuestionTypeServicee
          )
          : base(repository)
      {
          _repository = repository;
          _iQuestionTypeServicee = iQuestionTypeServicee;
      }
      public IEnumerable<PackageSource> GetAllPackageSource()
      {
          return _repository.Query().Select();
      }
      public IEnumerable<PackageSource> GetActivePackageSource(bool IsActive)
      {
          return _repository
                 .Query()
                 .Select();
      }

      public PackageSource GetPackageSourceById(int Id)
      {
          return _repository
              .Query(x => x.Id == Id)
              .Select().FirstOrDefault();
      }
      public PackageSource newPackageSource()
      {
          var lstTypes = new List<KeyValuePair<int, string>>();
          _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
          {
              lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
          });

          PackageSource objPackageSource = new PackageSource();
          // objPackageSource.kvpQuestionType = lstTypes;
          return objPackageSource;
      }
  }
}
