using HMS.Entities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Models
{
    public interface IBinaryObjectService
    {
        BinaryObject Find(params object[] keyValues);
        void Insert(BinaryObject entity);
        void Update(BinaryObject entity);
        void Delete(object id);
        void Delete(BinaryObject entity);
        IEnumerable<BinaryObject> GetAllBinaryObject();
        BinaryObject GetBinaryObjectById(int RefObjectKey, int objectTypeId);
        BinaryObject GetBinaryObject(int BinaryObjectsId, int RefObjectKey, int objectTypeId);
        List<BinaryObject>  GetBinaryObject(int RefObjectKey, int objectTypeId);
    }
    public class BinaryObjectService : Service<BinaryObject>, IBinaryObjectService
    {
        private readonly IRepositoryAsync<BinaryObject> _repository;
        public BinaryObjectService(IRepositoryAsync<BinaryObject> repository)
            : base(repository)
        {
            _repository = repository;
        }
        public IEnumerable<BinaryObject> GetAllBinaryObject()
        {
            return _repository
                .Query()
                .Select();
        }

        public BinaryObject GetBinaryObject(int BinaryObjectsId, int RefObjectKey, int objectTypeId)
        {
            return _repository
                .Query(x => x.RefObjectKey == RefObjectKey && x.RefObjectTypeId == objectTypeId && x.BinaryObjectsId == BinaryObjectsId)
                .Select().FirstOrDefault();
        }
        public BinaryObject GetBinaryObjectById(int RefObjectKey, int objectTypeId)
        {
            return _repository
                .Query(x => x.RefObjectKey == RefObjectKey && x.RefObjectTypeId == objectTypeId)
                .Select().FirstOrDefault();
        }
        public List<BinaryObject> GetBinaryObject(int RefObjectKey, int objectTypeId)
        {
            List<BinaryObject> binaryObject = new List<BinaryObject>();
            ArrayList items = new ArrayList();
            var binaryObject1= _repository
               .Query(x => x.RefObjectKey == RefObjectKey && x.RefObjectTypeId == objectTypeId)
                .Select(x => new  
                {
                    x.BinaryObjectsId,
                    x.RefObjectKey,
                    x.RefObjectTypeId
                }).ToList();

            foreach (var item in binaryObject1)
            {
                BinaryObject objBinaryObject = new BinaryObject();
                objBinaryObject.RefObjectTypeId = item.RefObjectTypeId;
                objBinaryObject.BinaryObjectsId = item.BinaryObjectsId;
                objBinaryObject.RefObjectKey = item.RefObjectKey;
                binaryObject.Add(objBinaryObject);
            }
            return binaryObject;
           
             
        }
    }
}