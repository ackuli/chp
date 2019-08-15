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
    public interface IPackageSubscribeService
    {
        PackageSubscribe Find(params object[] keyValues);
        void Insert(PackageSubscribe entity);
        void Update(PackageSubscribe entity);
        void Delete(object id);
        void Delete(PackageSubscribe entity);
        IEnumerable<PackageSubscribe> GetAllPackageSubscribe();
        IEnumerable<PackageSubscribe> GetVisiblePackageSubscribe(bool IsVisible);
        PackageSubscribe GetPackageSubscribeById(int Id);
        PackageSubscribe newPackageSubscribe();
    }
    public class PackageSubscribeService : Service<PackageSubscribe>, IPackageSubscribeService
    {
         private readonly IRepositoryAsync<PackageSubscribe> _repository;

         public PackageSubscribeService(

             IRepositoryAsync<PackageSubscribe> repository
          
           )
           : base(repository)
       {
           _repository = repository;
        
       }
       public IEnumerable<PackageSubscribe> GetAllPackageSubscribe()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<PackageSubscribe> GetVisiblePackageSubscribe(bool IsVisible)
       {
           return _repository
                  .Query()
                  .Select();
       }

       public PackageSubscribe GetPackageSubscribeById(int Id)
       {
           return _repository
               .Query()
               .Select().FirstOrDefault();
       }
       public PackageSubscribe newPackageSubscribe()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
          
           PackageSubscribe objPackageSubscribe = new PackageSubscribe();          
           return objPackageSubscribe;
       }
    }
}
