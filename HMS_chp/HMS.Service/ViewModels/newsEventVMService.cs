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
    public interface InewsEventVMService
    {
        newsEventVM newnewsEventVM();
        newsEventVM GetNewsAndEventsInfo();
    }
    public class newsEventVMService : InewsEventVMService
    {
        private readonly IEventsTypesService _iEventsTypesService;
        private readonly IAdvertisePositionService _iAdvertisePositionService;
        private readonly IAdvertissService _iAdvertissService;
        private readonly INewssService _iNewssService;
        private readonly IEventService _iEventService;
        
        public newsEventVMService(
             IAdvertisePositionService iAdvertisePositionService
              ,IAdvertissService iAdvertissService
                ,IEventsTypesService iEventsTypesService
            , INewssService iNewssService
        , IEventService iEventService
        
             )
        {
            _iEventService = iEventService;
            _iNewssService = iNewssService;
            _iEventsTypesService = iEventsTypesService;
            _iAdvertisePositionService = iAdvertisePositionService;
            _iEventsTypesService = iEventsTypesService;

        }
        public newsEventVM newnewsEventVM()
        {
            var lstTypes = new List<KeyValuePair<int, string>>();
            _iEventsTypesService.GetAllEventsType().ToList().ForEach(delegate(EventsType item)
            {
                lstTypes.Add(new KeyValuePair<int, string>(item.EventsTypeId, item.EventsTypeName));
            });

            newsEventVM objnewsEventVM = new newsEventVM();
            objnewsEventVM.EventTypeList = lstTypes;
            return objnewsEventVM;
        }

        public newsEventVM GetNewsAndEventsInfo()
        {
            newsEventVM objnewsEventVM = new newsEventVM();
            var advertisePosition = _iAdvertisePositionService.GetActiveAdvertisePositionByPageId(true, Convert.ToInt32(utility.PageType.NewsAndEvents));           
            objnewsEventVM.advertisePosition = advertisePosition;
            objnewsEventVM.LstNewses = _iNewssService.GetActiveNews(true).OrderByDescending(x => x.SourceDate).Take(4).ToList();
            if (objnewsEventVM.LstNewses.Count==0)
            {
                objnewsEventVM.LstNewses = _iNewssService.GetDefaultNews(true, true).OrderByDescending(x => x.SourceDate).Take(4).ToList();
            }
            objnewsEventVM.LstArchiveNews = _iNewssService.GetArchiveNews(true).OrderByDescending(x => x.SourceDate).Take(4).ToList();

            objnewsEventVM.EventsList = _iEventService.GetActivEvent(true).OrderBy(x => x.EventsDate.Day).Take(4).ToList();
            if (objnewsEventVM.EventsList.ToList().Count==0)
            {
                objnewsEventVM.EventsList = _iEventService.GetDefaultEvent(true, true).OrderByDescending(x => x.EventsDate.Day).Take(4).ToList();
            }

            objnewsEventVM.LstArchiveEvent = _iEventService.GetArchiveEvent(true).OrderByDescending(x => x.EventsDate).Take(4).ToList();
            return objnewsEventVM;
        }
    }
}
