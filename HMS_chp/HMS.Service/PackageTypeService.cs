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

    public interface IPackageTypeService
   {
       PackageType Find(params object[] keyValues);
       void Insert(PackageType entity);
       void Update(PackageType entity);
       void Delete(object id);
       void Delete(PackageType entity);
       IEnumerable<PackageType> GetAllPackageType();
       IEnumerable<PackageType> GetVisiblePackageType(bool IsVisible);
       PackageType GetPackageTypeById(int Id);
       PackageType newPackageType();
       // PackageType Add(PackageType project);
   }
    public class PackageTypeService : Service<PackageType>, IPackageTypeService
   {
       private readonly IRepositoryAsync<PackageType> _repository;

       public PackageTypeService(

             IRepositoryAsync<PackageType> repository
         
           )
           : base(repository)
       {
           _repository = repository;
          
       }
       public IEnumerable<PackageType> GetAllPackageType()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<PackageType> GetVisiblePackageType(bool IsVisible)
       {
           return _repository
                  .Query()
                  .Select();
       }

       public PackageType GetPackageTypeById(int Id)
       {
           return _repository
               .Query(x => x.PackageTypeId == Id)
               .Select().FirstOrDefault();
       }
       public PackageType newPackageType()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
           //_iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
           //{
           //    lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
           //});

           PackageType objPackageType = new PackageType();
           // objPackageType.kvpQuestionType = lstTypes;
           return objPackageType;
       }
   }
}
