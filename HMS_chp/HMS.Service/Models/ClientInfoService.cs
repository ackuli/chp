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
  
   public interface IClientInfosService
   {
       ClientInfo Find(params object[] keyValues);
       void Insert(ClientInfo entity);
       void Update(ClientInfo entity);
       void Delete(object id);
       void Delete(ClientInfo entity);
       IEnumerable<ClientInfo> GetAllClientInfo();
       IEnumerable<ClientInfo> GetActiveClientInfo(bool IsActive);
       ClientInfo GetClientInfoById(int Id);
       ClientInfo newClientInfo();
       // ClientInfo Add(ClientInfo project);
   }
   public class ClientInfoService : Service<ClientInfo>, IClientInfosService
   {
       private readonly IRepositoryAsync<ClientInfo> _repository;
       private readonly IQuestionTypeService _iQuestionTypeServicee;
       public ClientInfoService(

             IRepositoryAsync<ClientInfo> repository
           , IQuestionTypeService iQuestionTypeServicee
           )
           : base(repository)
       {
           _repository = repository;
           _iQuestionTypeServicee = iQuestionTypeServicee;
       }
       public IEnumerable<ClientInfo> GetAllClientInfo()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<ClientInfo> GetActiveClientInfo(bool IsActive)
       {
           return _repository
                  .Query()
                  .Select();
       }

       public ClientInfo GetClientInfoById(int Id)
       {
           return _repository
               .Query(x => x.ClientId == Id)
               .Select().FirstOrDefault();
       }
       public ClientInfo newClientInfo()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
           _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
           {
               lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
           });

           ClientInfo objClientInfo = new ClientInfo();
          // objClientInfo.kvpQuestionType = lstTypes;
           return objClientInfo;
       }
   }
}
