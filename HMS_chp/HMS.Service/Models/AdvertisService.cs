using HMS.Entities.Models;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HMS.Service.Models
{

    public interface IAdvertissService
    {
        Advertis Find(params object[] keyValues);
        IEnumerable<Advertis> GetAllAdvertis();
        IEnumerable<Advertis> GetVisibleAdvertis(bool IsVisible);
        IEnumerable<Advertis> GetAdvertisByPositionsId(int AdvertisePositionsId);
        IEnumerable<Advertis> GetActiveAdvertisByPositionsId(int AdvertisePositionsId,bool IsActive,DateTime startdate, DateTime enddate);
        Advertis GetAdvertisById(int Id);
        Advertis newAdvertis();
        void Insert(Advertis entity);
        void Update(Advertis entity);
        void Delete(object id);
        void Delete(Advertis entity);
        bool SaveAdvertiseBinaryobj(Advertis advertis, IEnumerable<HttpPostedFileBase> files, IUnitOfWork _unitOfWork);

    }
    public class AdvertisService : Service<Advertis>, IAdvertissService
    {
        private readonly IRepositoryAsync<Advertis> _repository;
        private readonly IQuestionTypeService _iQuestionTypeServicee;
        private readonly IBinaryObjectService _iBinaryObjectService;
        public AdvertisService(

              IRepositoryAsync<Advertis> repository
            , IQuestionTypeService iQuestionTypeServicee
            , IBinaryObjectService iBinaryObjectService
            )
            : base(repository)
        {
            _repository = repository;
            _iQuestionTypeServicee = iQuestionTypeServicee;
            _iBinaryObjectService = iBinaryObjectService;
        }
        public IEnumerable<Advertis> GetAllAdvertis()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<Advertis> GetVisibleAdvertis(bool IsVisible)
        {
            return _repository
                   .Query()
                   .Select();
        }
        public byte[] ConvertsToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public bool UpdateAdvertiseBinaryobj(Advertis advertis, IEnumerable<HttpPostedFileBase> files, IUnitOfWork _unitOfWork)
        {
            bool OperationType = false;
            _unitOfWork.BeginTransaction(IsolationLevel.Unspecified);
            try
            {
                advertis.LastUpdatedTime = DateTime.Now;
                advertis.SetBy = "1233";
                advertis.SetDate = DateTime.Now;
                _repository.Update(advertis);
                _unitOfWork.SaveChanges();
                if (advertis.AdvertiseTypeId == 1)
                {
                    BinaryObject objbinaryObject = new BinaryObject();
                    if (files.ToList().Count != 0)
                    {
                        files.ToList().ForEach(delegate(HttpPostedFileBase file)
                        {
                            var imagebyte = ConvertsToBytes(file);
                            objbinaryObject.Object = imagebyte;
                            objbinaryObject.RefObjectKey = advertis.AdvertiseId;
                            objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.Advertise;
                            objbinaryObject.Name = file.FileName;
                            objbinaryObject.Extension = file.ContentType;
                            _iBinaryObjectService.Insert(objbinaryObject);
                            _unitOfWork.SaveChanges();
                        });


                    }
                }

                _unitOfWork.Commit();
                OperationType = true;

            }
            catch (Exception mgs)
            {
                OperationType = false;
                _unitOfWork.Rollback();
            }
            return OperationType;
        }
        public bool SaveAdvertiseBinaryobj(Advertis advertis, IEnumerable<HttpPostedFileBase> files, IUnitOfWork _unitOfWork)
        {
            bool OperationType = false;
            _unitOfWork.BeginTransaction(IsolationLevel.Unspecified);
            try
            {
                advertis.LastUpdatedTime = DateTime.Now;
                advertis.SetBy = "1233";
                advertis.SetDate = DateTime.Now;
                _repository.Insert(advertis);
                _unitOfWork.SaveChanges();
                if (advertis.AdvertiseTypeId == 1)
                {
                    BinaryObject objbinaryObject = new BinaryObject();
                    if (files.ToList().Count != 0)
                    {
                        files.ToList().ForEach(delegate(HttpPostedFileBase file)
                        {
                            if (file != null)
                            {
                                var imagebyte = ConvertsToBytes(file);
                                objbinaryObject.Object = imagebyte;
                                objbinaryObject.RefObjectKey = advertis.AdvertiseId;
                                objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.Advertise;
                                objbinaryObject.Name = file.FileName;
                                objbinaryObject.Extension = file.ContentType;
                                _iBinaryObjectService.Insert(objbinaryObject);
                                _unitOfWork.SaveChanges();
                            }
                        });


                    }
                }

                _unitOfWork.Commit();
                OperationType = true;

            }
            catch (Exception mgs)
            {
                OperationType = false;
                _unitOfWork.Rollback();
            }
            return OperationType;
        }
        public IEnumerable<Advertis> GetAdvertisByPositionsId(int AdvertisePositionsId)
        {
            return _repository
               .Query(x => x.AdvertisePositionsId == AdvertisePositionsId)
               .Select();
        }
        public IEnumerable<Advertis> GetActiveAdvertisByPositionsId(int AdvertisePositionsId, bool IsActive,DateTime startDate, DateTime endDate)
        {
              return _repository
               .Query(x => x.AdvertisePositionsId == AdvertisePositionsId && x.IsActive == IsActive )//&& (x.StartDate <= startDate.Date && x.EndDate>= endDate.Date))
               .Select();
        }
        public Advertis GetAdvertisById(int Id)
        {
            return _repository
                .Query(x => x.AdvertiseId == Id)
                .Select().FirstOrDefault();
        }
        public Advertis newAdvertis()
        {
            var lstTypes = new List<KeyValuePair<int, string>>();
            _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
            {
                lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
            });

            Advertis objAdvertis = new Advertis();
            //  objAdvertis.kvpQuestionType = lstTypes;
            return objAdvertis;
        }
    }
}
