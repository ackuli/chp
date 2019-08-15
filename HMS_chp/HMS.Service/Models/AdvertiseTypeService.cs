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
    public interface IAdvertiseTypeService
    {
        AdvertiseType Find(params object[] keyValues);
        IEnumerable<AdvertiseType> GetAllAdvertiseType();
        IEnumerable<AdvertiseType> GetActiveAdvertiseType(bool IsActive);
        AdvertiseType GetAdvertiseTypeById(int Id);     
        void Insert(AdvertiseType entity);
        void Update(AdvertiseType entity);
        void Delete(object id);
        void Delete(AdvertiseType entity);
    }
    public class AdvertiseTypeService : Service<AdvertiseType>, IAdvertiseTypeService

    {
        private readonly IRepositoryAsync<AdvertiseType> _repository;
      
        public AdvertiseTypeService(

                IRepositoryAsync<AdvertiseType> repository
            
            )
            : base(repository)
        {
            _repository = repository;
            
        }
        public IEnumerable<AdvertiseType> GetAllAdvertiseType()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<AdvertiseType> GetActiveAdvertiseType(bool IsActive)
        {
            return _repository
                   .Query()
                   .Select();
        }

        public AdvertiseType GetAdvertiseTypeById(int Id)
        {
            return _repository
                .Query(x => x.AdvertiseTypeId == Id)
                .Select().FirstOrDefault();
        }
      
    }
 
}
