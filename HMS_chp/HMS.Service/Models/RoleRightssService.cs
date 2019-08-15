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
   
   public interface IRoleRightsssService
   {
       RoleRightss Find(params object[] keyValues);
       void Insert(RoleRightss entity);
       void Update(RoleRightss entity);
       void Delete(object id);
       void Delete(RoleRightss entity);
       IEnumerable<RoleRightss> GetAllRoleRightss();
       IEnumerable<RoleRightss> GetActiveRoleRightss(bool IsActive);
       RoleRightss GetRoleRightssById(int Id);
       IEnumerable<RoleRightss> GetRightsByRoleIdAndAreaId(int RoleId, int clientId);
       RoleRightss newRoleRightss();
       // RoleRightss Add(RoleRightss project);
   }
   public class RoleRightssService : Service<RoleRightss>, IRoleRightsssService
   {
       private readonly IRepositoryAsync<RoleRightss> _repository;
       private readonly IQuestionTypeService _iQuestionTypeServicee;
       public RoleRightssService(
             IRepositoryAsync<RoleRightss> repository
           , IQuestionTypeService iQuestionTypeServicee
           )
           : base(repository)
       {
           _repository = repository;
           _iQuestionTypeServicee = iQuestionTypeServicee;
       }

       public IEnumerable<RoleRightss> GetRightsByRoleIdAndAreaId(int RoleId, int clientId)
       {
           return  _repository.Query().Include(x=>x.Client)
                   .Select()
                   
                   .Where(x => x.ClientId == clientId && x.RoleId == RoleId);
       }
       public IEnumerable<RoleRightss> GetAllRoleRightss()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<RoleRightss> GetActiveRoleRightss(bool IsActive)
       {
           return _repository
                  .Query()
                  .Select();
       }

       public RoleRightss GetRoleRightssById(int Id)
       {
           return _repository
                  .Query(x => x.RoleRightsId == Id)
                  .Select().FirstOrDefault();
       }
       public RoleRightss newRoleRightss()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
           _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
           {
               lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
           });

           RoleRightss objRoleRightss = new RoleRightss();
           // objRoleRightss.kvpQuestionType = lstTypes;
           return objRoleRightss;
       }
   }
}
