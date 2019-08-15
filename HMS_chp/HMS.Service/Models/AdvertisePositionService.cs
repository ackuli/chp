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
    public interface IAdvertisePositionService
    {
        void Insert(AdvertisePosition entity);
        void Update(AdvertisePosition entity);
        void Delete(object id);
        void Delete(AdvertisePosition entity);        
        AdvertisePosition Find(params object[] keyValues);
        IEnumerable<AdvertisePosition> GetAllAdvertisePosition();
        IEnumerable<AdvertisePosition> GetActiveAdvertisePosition(bool IsActive);
        AdvertisePosition GetAdvertisePositionById(int Id);
        AdvertisePosition newAdvertisePosition();
        IEnumerable<AdvertisePosition> GetActiveAdvertisePositionByPageId(bool IsActive,int pageId);
       
    }
    public class AdvertisePositionService : Service<AdvertisePosition>, IAdvertisePositionService
    {
         private readonly IRepositoryAsync<AdvertisePosition> _repository;
        private readonly IQuestionTypeService _iQuestionTypeServicee;
        private readonly IAdvertissService _iAdvertissService;
        private readonly IBinaryObjectService _ibinaryObjectService;
        
        public AdvertisePositionService(

               IRepositoryAsync<AdvertisePosition> repository
              ,IQuestionTypeService iQuestionTypeServicee
              ,IAdvertissService iAdvertissService
              ,IBinaryObjectService ibinaryObjectService
            )
            : base(repository)
        {
            _repository = repository;
            _iQuestionTypeServicee = iQuestionTypeServicee;
            _iAdvertissService = iAdvertissService;
            _ibinaryObjectService = ibinaryObjectService;
        }
        public IEnumerable<AdvertisePosition> GetAllAdvertisePosition()
        {
            return _repository.Query().Include(x=>x.PageType).Include(x=>x.CurrencyType1).Select();
        }
        public IEnumerable<AdvertisePosition> GetActiveAdvertisePosition(bool IsActive)
        {
            return _repository
                   .Query()
                   .Select();
        }

        public AdvertisePosition GetAdvertisePositionById(int Id)
        {
           var  advertisePositions= _repository
                                    .Query(x => x.AdvertisePositionsId == Id)
                                    .Select().FirstOrDefault();

           var advertise = _iAdvertissService.GetAdvertisByPositionsId(advertisePositions.AdvertisePositionsId);
            advertisePositions.advertisList=advertise;
            return advertisePositions;
               
        }
        public AdvertisePosition newAdvertisePosition()
        {
            var lstTypes = new List<KeyValuePair<int, string>>();
           _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
            {
                lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
            });

           AdvertisePosition objadvertisePosition = new AdvertisePosition();          
           return objadvertisePosition;
        }
        public IEnumerable<AdvertisePosition> GetActiveAdvertisePositionByPageId(bool IsActive, int pageId)
        {
            var advertisePosition = _repository
                                    .Query(x => x.PageId == pageId)
                                    .Select();                       
            advertisePosition.ToList().ForEach(delegate(AdvertisePosition item)
            {
                item.Advertises = _iAdvertissService.GetActiveAdvertisByPositionsId(item.AdvertisePositionsId, true, DateTime.Now, DateTime.Now).ToList();
                //item.Advertises.ToList().ForEach(delegate(Advertis itemAdvertis) {
                foreach( var itemAdvertis in item.Advertises){
                    itemAdvertis.binaryObjectList = _ibinaryObjectService.GetBinaryObject(itemAdvertis.AdvertiseId, Convert.ToInt32(utility.binaryObjectTypes.Advertise));  
                }
                   
                //});
            });

            return advertisePosition;      
        }
    }
}
