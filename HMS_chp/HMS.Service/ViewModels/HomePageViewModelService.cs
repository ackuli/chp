using HMS.Entities.Models;
using HMS.Entities.ViewModels;
using HMS.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.ViewModels
{
    public interface IHomePageViewModelService
    {
        HomePageViewModel GetHomePageInfo();
        HomePageViewModel GetHomePageInfoForMoc4();
    }
    public class HomePageViewModelService : IHomePageViewModelService
    {

        private readonly IAdvertisePositionService _iAdvertisePositionService;
        private readonly IAdvertissService _iAdvertissService;
        private readonly IBinaryObjectService _iBinaryObjectService;
        private readonly IExperiencesService _iExperiencesService;
        private readonly IPackagesInfoService _iPackagesInfoService;
        private readonly IHotelsService _iHotelsService;
        private readonly IPeoplePerRoomsService _iPeoplePerRoomsService;
        private readonly IDurationsService _iDurationsService;
        private readonly IShiftingService _iShiftingService;



        public HomePageViewModelService(
               IAdvertisePositionService iAdvertisePositionService
              , IAdvertissService iAdvertissService
              , IBinaryObjectService iBinaryObjectService
              , IExperiencesService iExperiencesService
              , IPackagesInfoService iPackagesInfoService
              , IHotelsService iHotelsService
              , IPeoplePerRoomsService iPeoplePerRoomsService
              , IDurationsService iDurationsService
              , IShiftingService iShiftingService
            )
        {

            _iAdvertisePositionService = iAdvertisePositionService;
            _iAdvertissService = iAdvertissService;
            _iBinaryObjectService = iBinaryObjectService;
            _iExperiencesService = iExperiencesService;
            _iPackagesInfoService = iPackagesInfoService;
            _iHotelsService = iHotelsService;
            _iPeoplePerRoomsService = iPeoplePerRoomsService;
            _iDurationsService = iDurationsService;
            _iShiftingService = iShiftingService;
        }
        public HomePageViewModel GetHomePageInfoForMoc4()
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.lstFeaturedPackages = _iPackagesInfoService.GetAllFeaturedPackagesInfo().ToList();
            var advertisePosition = _iAdvertisePositionService.GetActiveAdvertisePositionByPageId(true, Convert.ToInt32(utility.PageType.HomePage));
            homePageViewModel.advertisePosition = advertisePosition;
            return homePageViewModel;
        }
        public HomePageViewModel GetHomePageInfo()
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            var advertisePosition = _iAdvertisePositionService.GetActiveAdvertisePositionByPageId(true, Convert.ToInt32(utility.PageType.HomePage));
            homePageViewModel.experience = _iExperiencesService.GetActiveExperience(true).ToList();
            homePageViewModel.advertisePosition = advertisePosition;

            var lstdurations = new List<KeyValuePair<int, string>>();
            _iDurationsService.GetAllDuration().ToList().ForEach(delegate(Duration item)
            {
                lstdurations.Add(new KeyValuePair<int, string>(item.DurationId, item.DuratioName));
            });
            var lsthotelclass = new List<KeyValuePair<int, string>>();
            _iHotelsService.GetAllHotel().ToList().ForEach(delegate(Hotel item)
            {
                lsthotelclass.Add(new KeyValuePair<int, string>(item.Id, item.Star));
            });
            var lstpeopleperrooms = new List<KeyValuePair<int, string>>();
            _iPeoplePerRoomsService.GetActivePeoplePerRoom(true).ToList().ForEach(delegate(PeoplePerRoom item)
            {
                lstpeopleperrooms.Add(new KeyValuePair<int, string>(item.Id, item.RoomCapacity));
            });

            var listShifting = new List<KeyValuePair<int, string>>();
            _iShiftingService.GetAllShifting().ToList().ForEach(delegate(Shifting item)
            {
                listShifting.Add(new KeyValuePair<int, string>(item.ShiftingId, item.ShiftingName));
            });

            homePageViewModel.kvplistShifting = listShifting;
            homePageViewModel.kvplistDurations = lstdurations;
            homePageViewModel.kvplistHotelClass = lsthotelclass;
            homePageViewModel.kvplistPeoplePerRoom = lstpeopleperrooms;
            homePageViewModel.lstFeaturedPackages = _iPackagesInfoService.GetAllFeaturedPackagesInfo().ToList();

            return homePageViewModel;
        }

    }
}
