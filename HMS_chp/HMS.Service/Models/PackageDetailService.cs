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
   public interface IPackageDetailsService
   {
       PackageDetail Find(params object[] keyValues);
       void Insert(PackageDetail entity);
       void Update(PackageDetail entity);
       void Delete(object id);
       void Delete(PackageDetail entity);
       IEnumerable<PackageDetail> GetAllPackageDetail();
       IEnumerable<PackageDetail> GetActivePackageDetail(bool IsActive);
       PackageDetail GetPackageDetailById(int Id);
       PackageDetail newPackageDetail();
       // PackageDetail Add(PackageDetail project);
   }
   public class PackageDetailService : Service<PackageDetail>, IPackageDetailsService
   {
       private readonly IRepositoryAsync<PackageDetail> _repository;
       private readonly IQuestionTypeService _iQuestionTypeServicee;
       public PackageDetailService(

             IRepositoryAsync<PackageDetail> repository
           , IQuestionTypeService iQuestionTypeServicee
           )
           : base(repository)
       {
           _repository = repository;
           _iQuestionTypeServicee = iQuestionTypeServicee;
       }
       public IEnumerable<PackageDetail> GetAllPackageDetail()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<PackageDetail> GetActivePackageDetail(bool IsActive)
       {
           return _repository
                  .Query()
                  .Select();
       }

       public PackageDetail GetPackageDetailById(int Id)
       {
           return _repository
               .Query(x => x.Id == Id)
               .Select().FirstOrDefault();
       }
       public PackageDetail newPackageDetail()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
           _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
           {
               lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
           });

           PackageDetail objPackageDetail = new PackageDetail();
           // objPackageDetail.kvpQuestionType = lstTypes;
           return objPackageDetail;
       }
   }
}
