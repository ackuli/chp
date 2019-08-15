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
    public interface IClientService
    {
        Client Find(params object[] keyValues);
        void Insert(Client entity);
        void Update(Client entity);
        void Delete(object id);
        void Delete(Client entity);
        IEnumerable<Client> GetAllClient();
        IEnumerable<Client> GetActiveClient(bool IsActive);
        Client GetClientById(int Id);
        IEnumerable<Client> GetClientListById(int Id);
        Client newClient();
        List<KeyValuePair<int, string>> GetKVP();
        // Client Add(Client project);
    }
    public class ClientService : Service<Client>, IClientService
    {
        private readonly IRepositoryAsync<Client> _repository;
        private readonly IQuestionTypeService _iQuestionTypeServicee;
        private readonly IBinaryObjectService _iBinaryObjectService;
        public ClientService(

              IRepositoryAsync<Client> repository
            , IQuestionTypeService iQuestionTypeServicee
            , IBinaryObjectService iBinaryObjectService
            )
            : base(repository)
        {
            _repository = repository;
            _iQuestionTypeServicee = iQuestionTypeServicee;
            _iBinaryObjectService = iBinaryObjectService;
        }
        public IEnumerable<Client> GetAllClient()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<Client> GetClientListById(int Id)
        {
            return _repository.Query(x=>x.ClientId==Id).Select();
        }
        public IEnumerable<Client> GetActiveClient(bool IsActive)
        {
            return _repository
                   .Query()
                   .Select();
        }

        public Client GetClientById(int Id)
        {
          var binaryObject=  _iBinaryObjectService.GetBinaryObjectById(Id,9);

            
            var Client= _repository
                .Query(x => x.ClientId == Id)
                .Select().FirstOrDefault();

            Client.binaryObject = binaryObject;
            return Client;
        }
        public Client newClient()
        {
            //var lstTypes = new List<KeyValuePair<int, string>>();
            //_iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
            //{
            //    lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
            //});
            var ministryApprovalList = new List<KeyValuePair<int, string>>();
            ministryApprovalList.Add(new KeyValuePair<int, string>(1, "Approved by the Saudi Hajj Ministry"));
            ministryApprovalList.Add(new KeyValuePair<int, string>(2, "Approved by the Saudi Umrah Ministry"));
            ministryApprovalList.Add(new KeyValuePair<int, string>(3, "Approved by the Saudi Both Ministry"));
            Client objClient = new Client();
            objClient.ministryApprovalList = ministryApprovalList;
            return objClient;
        }

        public List<KeyValuePair<int, string>> GetKVP()
        {
            var data = _repository.Query().Select().ToList();
            var typeList = new List<KeyValuePair<int, string>>();
            data.ForEach(c => typeList.Add(new KeyValuePair<int, string>(c.ClientId, c.ClientName)));

            return typeList;
        }
    }
}
