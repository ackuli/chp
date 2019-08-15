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
   public interface IBinaryObjectTypesService
   {
       BinaryObjectType Find(params object[] keyValues);
       void Insert(BinaryObjectType entity);
       void Update(BinaryObjectType entity);
       void Delete(object id);
       void Delete(BinaryObjectType entity);
       IEnumerable<BinaryObjectType> GetAllBinaryObjectType();
       IEnumerable<BinaryObjectType> GetVisibleBinaryObjectType(bool IsActive);
       BinaryObjectType GetBinaryObjectTypeById(int Id);
      
   }
   public class BinaryObjectTypeService : Service<BinaryObjectType>, IBinaryObjectTypesService
   {
       private readonly IRepositoryAsync<BinaryObjectType> _repository;
    
       public BinaryObjectTypeService(
             IRepositoryAsync<BinaryObjectType> repository          
           )
           : base(repository)
       {
           _repository = repository;          
       }
       public IEnumerable<BinaryObjectType> GetAllBinaryObjectType()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<BinaryObjectType> GetVisibleBinaryObjectType(bool IsActive)
       {
           return _repository
                  .Query()
                  .Select();
       }

       public BinaryObjectType GetBinaryObjectTypeById(int Id)
       {
           return _repository
               .Query(x => x.BinaryObjectsTypeId == Id)
               .Select().FirstOrDefault();
       }
      
   }
}
