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


    public interface IClientInformationService
    {
        ClientInformation Find(params object[] keyValues);
        void Insert(ClientInformation entity);
        void Update(ClientInformation entity);
        void Delete(object id);
        void Delete(ClientInformation entity);
        IEnumerable<ClientInformation> GetAllClientInformation();
        IEnumerable<ClientInformation> GetVisibleClientInformation(bool IsVisible);
        ClientInformation GetClientInformationById(int Id);
        ClientInformation newClientInformation();
        IEnumerable<ClientInformation> GetClientInformationByCategory(int QuestionType, string keyword);
        IEnumerable<ClientInformation> GetClientInformationByKeyWords(string keyword);
        IEnumerable<ClientInformation> GetFrequentAskClientInformation(bool IsVisible, bool IsFrequentAsk);

    }

  public  class ClientInformationService: Service<ClientInformation>, IClientInformationService
    {
      
        private readonly IRepositoryAsync<ClientInformation> _repository;
        private readonly IQuestionTypeService _iQuestionTypeServicee;
        public ClientInformationService(

              IRepositoryAsync<ClientInformation> repository
            , IQuestionTypeService iQuestionTypeServicee
            )
            : base(repository)
        {
            _repository = repository;
            _iQuestionTypeServicee = iQuestionTypeServicee;
        }
        public IEnumerable<ClientInformation> GetAllClientInformation()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<ClientInformation> GetVisibleClientInformation(bool IsVisible)
        {
            return _repository
                   .Query()
                   .Select();
        }
        public IEnumerable<ClientInformation> GetFrequentAskClientInformation(bool IsVisible,bool IsFrequentAsk)
        {
            return _repository
                   .Query()
                   .Select();
        }
        public ClientInformation GetClientInformationById(int Id)
        {
            return _repository
                .Query(x => x.ClientId == Id)
                .Select().FirstOrDefault();
        }
        public ClientInformation newClientInformation()
        {
            var lstTypes = new List<KeyValuePair<int, string>>();
           _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
            {
                lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
            });

            ClientInformation objClientInformation = new ClientInformation();
           // objClientInformation.kvpQuestionType = lstTypes;
            return objClientInformation;
        }
        public IEnumerable<ClientInformation> GetClientInformationByCategory(int QuestionType,string keyword)
        {
            //if (keyword==null)
            //{
            //    return _repository
            //    .Query(x => x.TypeId == QuestionType || x.KeyWords.Contains(keyword) && x.Answer!=null)
            //    .Select();             
            //}
            //else
            //{
            //    return _repository
            //    .Query(x => x.TypeId == QuestionType && x.Question.Contains(keyword) && x.Answer != null) 
            //    .Select();             
            //}
            return _repository
                .Query()
                .Select();   
            
        }
        public IEnumerable<ClientInformation> GetClientInformationByKeyWords(string keyword)
        {
           
                return _repository
                .Query() 
                .Select();             
        }
    }
}
