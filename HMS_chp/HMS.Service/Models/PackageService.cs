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
 
  public interface IPackagesService
  {
      Package Find(params object[] keyValues);
      void Insert(Package entity);
      void Update(Package entity);
      void Delete(object id);
      void Delete(Package entity);
      IEnumerable<Package> GetAllPackage();
      IEnumerable<Package> GetActivePackage(bool IsActive);
      Package GetPackageById(int Id);
      Package newPackage();
      // Package Add(Package project);
  }
  public class PackageService : Service<Package>, IPackagesService
  {
      private readonly IRepositoryAsync<Package> _repository;
      private readonly IQuestionTypeService _iQuestionTypeServicee;
      public PackageService(

            IRepositoryAsync<Package> repository
          , IQuestionTypeService iQuestionTypeServicee
          )
          : base(repository)
      {
          _repository = repository;
          _iQuestionTypeServicee = iQuestionTypeServicee;
      }
      public IEnumerable<Package> GetAllPackage()
      {
          return _repository.Query().Select();
      }
      public IEnumerable<Package> GetActivePackage(bool IsActive)
      {
          return _repository
                 .Query()
                 .Select();
      }

      public Package GetPackageById(int Id)
      {
          return _repository
              .Query(x => x.Id == Id)
              .Select().FirstOrDefault();
      }
      public Package newPackage()
      {
          var lstTypes = new List<KeyValuePair<int, string>>();
          _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
          {
              lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
          });

          Package objPackage = new Package();
          // objPackage.kvpQuestionType = lstTypes;
          return objPackage;
      }
  }
}
