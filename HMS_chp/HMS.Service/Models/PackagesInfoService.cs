using HMS.Entities.Models;
using HMS.Entities.ViewModels;
using HMS.utility;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Models
{

    public interface IPackagesInfoService
    {
        PackagesInfo Find(params object[] keyValues);
        void Insert(PackagesInfo entity);
        void Update(PackagesInfo entity);
        void Delete(object id);
        void Delete(PackagesInfo entity);
        IEnumerable<PackagesInfo> GetAllPackagesInfo();
        IEnumerable<PackagesInfo> GetVisiblePackagesInfo();
        PackagesInfo GetPackagesInfoById(int Id);
        PackagesInfo newPackagesInfo();
        IEnumerable<PackagesInfo> GetPackagesInfoByCategory();        
        IEnumerable<PackagesInfo> GetPackagesInfo();
        IEnumerable<PackagesInfo> GetPackagesInfoBySearchCriteria(HomePageViewModel SearchCriteria);
        IEnumerable<PackagesInfo> GetAllPackagesInfo(int ClientId);
        IEnumerable<PackagesInfo> GetAllFeaturedPackagesInfo();
    }

  public  class PackagesInfoService : Service<PackagesInfo>, IPackagesInfoService
    {

        private readonly IRepositoryAsync<PackagesInfo> _repository;
        private readonly IDurationsService _iDurationsService;
        private readonly IPackageTypeService _iPackageTypeService;
        private readonly ICurrencyTypesService _iCurrencyTypesService;
        private readonly IHotelsService _iHotelsService;
        private readonly IPeoplePerRoomsService _iPeoplePerRoomsService;
        private readonly IPackageSubscribeService _iPackageSubscribeService;
        private readonly IPackageDisplayTypeSevice _iPackageDisplayTypeSevice;
        private readonly IDistanceUnitService _iDistanceUnitService;

        private readonly IShiftingService _iShiftingService;
        public PackagesInfoService(

             IRepositoryAsync<PackagesInfo> repository
            ,IDurationsService iDurationsService
            ,IPackageTypeService iPackageTypeService
            ,ICurrencyTypesService iCurrencyTypesService
            ,IPeoplePerRoomsService iPeoplePerRoomsService
            ,IShiftingService iShiftingService
            ,IHotelsService iHotelsService
            ,IPackageSubscribeService iPackageSubscribeService
            ,IPackageDisplayTypeSevice iPackageDisplayTypeSevice
            ,IDistanceUnitService iDistanceUnitService
            )
            : base(repository)
        {
            _repository = repository;
            _iDurationsService = iDurationsService;
            _iPackageTypeService = iPackageTypeService;
            _iCurrencyTypesService = iCurrencyTypesService;
            _iPeoplePerRoomsService = iPeoplePerRoomsService;
            _iShiftingService = iShiftingService;
            _iHotelsService = iHotelsService;
            _iPackageSubscribeService = iPackageSubscribeService;
            _iPackageDisplayTypeSevice = iPackageDisplayTypeSevice;
            _iDistanceUnitService = iDistanceUnitService;
        }
        public IEnumerable<PackagesInfo> GetAllPackagesInfo()
        {
            return _repository.Query()
                  .Include(x=>x.Statuss)
                  .Include(x => x.Client)
                  .Include(x=>x.PackageType)                  
                  .Select();
        }
        public IEnumerable<PackagesInfo> GetAllPackagesInfo(int ClientId)
        {
            return _repository.Query(x => x.ClientId == ClientId)
                  .Include(x => x.Statuss)
                  .Include(x => x.Client)
                  .Include(x => x.PackageType)
                  .Select();
        }
        public IEnumerable<PackagesInfo> GetVisiblePackagesInfo()
        {
            return _repository
                   .Query()
                   .Select();
        }
        public IEnumerable<PackagesInfo> GetPackagesInfo()
        {
            return _repository
                   .Query()
                   .Select();
        }
        public PackagesInfo GetPackagesInfoById(int Id)
        {
            return _repository
                .Query(x =>x.PackageId == Id)
                .Include(x => x.Duration1)
                .Include(x => x.Client)
                .Select().FirstOrDefault();
        }
        public IEnumerable<PackagesInfo> GetAllFeaturedPackagesInfo()
        {
            return _repository.Query((x=>x.PackagesubscribeId==1 || x.PackagesubscribeId==3 &&  x.StatusId==2))
                  .Include(x => x.Duration1)
                .Include(x => x.PeoplePerRoom)
                .Include(x => x.DistanceUnit)
                .Include(x => x.Client)
                .Include(x => x.PackageType)
                .Include(x => x.Shifting)
                .Include(x => x.Hotel)             
                .Select();
        }
        public IEnumerable<PackagesInfo> GetPackagesInfoBySearchCriteria(HomePageViewModel SearchCriteria)
        {
            int packageTypeId = 0;
            var predicate = PredicateBuilder.True<PackagesInfo>();
            if (SearchCriteria.IsHajjUmrah=="1")
            {
                packageTypeId = 1;
            }
            if (SearchCriteria.IsHajjUmrah == "2")
            {
                packageTypeId = 2;
            }
            if (SearchCriteria.PeoplePerRoomsId > 0)
                predicate = predicate.And(p => p.PeoplePerRooms == SearchCriteria.PeoplePerRoomsId);

            if (SearchCriteria.HotelclassId > 0)
                predicate = predicate.And(p => p.HotelClassId == SearchCriteria.HotelclassId);

            if (SearchCriteria.PackagesubscribeId > 0)
                predicate = predicate.And(p => p.PackagesubscribeId == SearchCriteria.PackagesubscribeId);

            if (SearchCriteria.DurationId > 0)
                predicate = predicate.And(p => p.Duration == SearchCriteria.DurationId);

            predicate = predicate.And(p => p.PackageTypeId == packageTypeId);
            predicate = predicate.And(p => p.StatusId == 2);
            predicate = predicate.And(p => p.PackagesubscribeId==2 || p.PackagesubscribeId==3);

            return _repository
                .Query(predicate)
                .Include(x => x.Duration1)
                .Include(x => x.PeoplePerRoom)
                .Include(x=>x.DistanceUnit)
                .Include(x => x.Client.ClientInformations)
                .Include(x => x.PackageType)
                .Include(x => x.Shifting)
                .Include(x => x.Hotel)
                .Include(x => x.Client)
                .Select();
            //return _repository
            //    .Query(x => x.PackageTypeId == packageTypeId
            //        && x.StatusId == 2 && (x.HotelClassId == SearchCriteria.HotelclassId
            //        || x.PackagesubscribeId == SearchCriteria.PackagesubscribeId
            //        || x.Duration == SearchCriteria.DurationId)
            //        )
            //    .Include(x=>x.Duration1)
            //    .Include(x => x.PeoplePerRoom)
            //    .Include(x => x.Client.ClientInformations)
            //    .Include(x => x.PackageType)
            //    .Include(x => x.Shifting)
            //    .Include(x => x.Hotel)
            //    .Include(x => x.Client)                
            //    .Select();
               
        }
        public PackagesInfo newPackagesInfo()
        {
            var lstTypes = new List<KeyValuePair<int, string>>();
            var lstduration = new List<KeyValuePair<int, string>>();
            var lstCurrencyType = new List<KeyValuePair<int, string>>();
            var lstpeoplePerRooms = new List<KeyValuePair<int, string>>();
            var lstPackageDisplayType = new List<KeyValuePair<int, string>>();
            var lstDistanceUnit = new List<KeyValuePair<int, string>>();

            _iDistanceUnitService.GetAllDistanceUnits().ToList().ForEach(delegate(DistanceUnit item)
            {
                lstDistanceUnit.Add(new KeyValuePair<int, string>(item.DistanceUnitId, item.DistanceUnitName));
            });

            _iDurationsService.GetAllDuration().ToList().ForEach(delegate(Duration item)
            {
                lstduration.Add(new KeyValuePair<int, string>(item.DurationId, item.DuratioName));
            });

            _iPackageTypeService.GetAllPackageType().ToList().ForEach(delegate(PackageType item)
            {
                lstTypes.Add(new KeyValuePair<int, string>(item.PackageTypeId, item.PackageTypename));
            });
            _iCurrencyTypesService.GetAllCurrencyType().ToList().ForEach(delegate(CurrencyType item)
            {
                lstCurrencyType.Add(new KeyValuePair<int, string>(item.CurrencyTypeId, item.CurrencyName));
            });

            _iPeoplePerRoomsService.GetActivePeoplePerRoom(true).ToList().ForEach(delegate(PeoplePerRoom item)
            {
                lstpeoplePerRooms.Add(new KeyValuePair<int, string>(item.Id, item.RoomCapacity));
            });

            _iPackageDisplayTypeSevice.GetAllPackageDisplayType().ToList().ForEach(delegate(PackageDisplayType item)
            {
                lstPackageDisplayType.Add(new KeyValuePair<int, string>(item.PackageDisplayTypeId, item.Name));
            });


            var listShifting = new List<KeyValuePair<int, string>>();
            _iShiftingService.GetAllShifting().ToList().ForEach(delegate(Shifting item)
            {
                listShifting.Add(new KeyValuePair<int, string>(item.ShiftingId, item.ShiftingName));
            });
            var lsthotelclass = new List<KeyValuePair<int, string>>();
            _iHotelsService.GetAllHotel().ToList().ForEach(delegate(Hotel item)
            {
                lsthotelclass.Add(new KeyValuePair<int, string>(item.Id, item.Star));
            });

            var lstPackageSubscribe = new List<KeyValuePair<int, string>>();
              _iPackageSubscribeService.GetAllPackageSubscribe().ToList().ForEach(delegate(PackageSubscribe item)
            {
                lstPackageSubscribe.Add(new KeyValuePair<int, string>(item.PackagesubscribeId, item.PackageSubscribeName));
            });
            
            PackagesInfo objPackagesInfo = new PackagesInfo();        
            objPackagesInfo.kvpPackagetype = lstTypes;
            objPackagesInfo.kvpDuration = lstduration;
            objPackagesInfo.kvpCurrencyType = lstCurrencyType;
            objPackagesInfo.kvpPeoplePerRoom = lstpeoplePerRooms;
            objPackagesInfo.kvplistShifting = listShifting;
            objPackagesInfo.kvplistHotelClass = lsthotelclass;
            objPackagesInfo.kvpPackagesubscribe = lstPackageSubscribe;
            objPackagesInfo.kvpPackageDisplayType = lstPackageDisplayType;
            objPackagesInfo.kvpDistanceUnit = lstDistanceUnit;

            return objPackagesInfo;
        }
        public IEnumerable<PackagesInfo> GetPackagesInfoByCategory()
        {            
            return _repository
                .Query()
                .Select();

        }
       
    }
    
}
