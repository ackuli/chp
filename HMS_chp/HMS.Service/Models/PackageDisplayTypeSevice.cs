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
  
    public interface IPackageDisplayTypeSevice
    {
        PackageDisplayType Find(params object[] keyValues);
        void Insert(PackageDisplayType entity);
        void Update(PackageDisplayType entity);
        void Delete(object id);
        void Delete(PackageDisplayType entity);
        IEnumerable<PackageDisplayType> GetAllPackageDisplayType();
        IEnumerable<PackageDisplayType> GetVisiblePackageDisplayType(bool IsVisible);
        PackageDisplayType GetPackageDisplayTypeById(int Id);

    }
    public class PackageDisplayTypeSevice : Service<PackageDisplayType>, IPackageDisplayTypeSevice
    {
        private readonly IRepositoryAsync<PackageDisplayType> _repository;
        private readonly IQuestionTypeService _iQuestionTypeServicee;
        public PackageDisplayTypeSevice(

              IRepositoryAsync<PackageDisplayType> repository
            , IQuestionTypeService iQuestionTypeServicee
            )
            : base(repository)
        {
            _repository = repository;
            _iQuestionTypeServicee = iQuestionTypeServicee;
        }
        public IEnumerable<PackageDisplayType> GetAllPackageDisplayType()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<PackageDisplayType> GetVisiblePackageDisplayType(bool IsVisible)
        {
            return _repository
                   .Query()
                   .Select();
        }
        public PackageDisplayType GetPackageDisplayTypeById(int Id)
        {
            return _repository
                .Query(x => x.PackageDisplayTypeId == Id)
                .Select().FirstOrDefault();
        }

    }
}
