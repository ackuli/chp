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
   
  
   public interface IRolesService
   {
       Role Find(params object[] keyValues);
       void Insert(Role entity);
       void Update(Role entity);
       void Delete(object id);
       void Delete(Role entity);
       IEnumerable<Role> GetAllRole();
       IEnumerable<Role> GetActiveRole(bool IsActive);
       Role GetRoleById(int Id);
       Role newRole();
       // Role Add(Role project);
       List<KeyValuePair<int, string>> GetKVP();
   }
   public class RoleService : Service<Role>, IRolesService
   {
       private readonly IRepositoryAsync<Role> _repository;
       private readonly IQuestionTypeService _iQuestionTypeServicee;
       public RoleService(

             IRepositoryAsync<Role> repository
           , IQuestionTypeService iQuestionTypeServicee
           )
           : base(repository)
       {
           _repository = repository;
           _iQuestionTypeServicee = iQuestionTypeServicee;
       }
       public IEnumerable<Role> GetAllRole()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<Role> GetActiveRole(bool IsActive)
       {
           return _repository
                  .Query()
                  .Select();
       }

       public Role GetRoleById(int Id)
       {
           return _repository
               .Query(x => x.RoleId == Id)
               .Select().FirstOrDefault();
       }
       public Role newRole()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
           _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
           {
               lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
           });

           Role objRole = new Role();
           // objRole.kvpQuestionType = lstTypes;
           return objRole;
       }
       public List<KeyValuePair<int, string>> GetKVP()
       {
           var data = _repository.Query().Select().ToList();
           var typeList = new List<KeyValuePair<int, string>>();
           data.ForEach(c => typeList.Add(new KeyValuePair<int, string>(c.RoleId, c.RoleName)));

           return typeList;
       }
   }
}
