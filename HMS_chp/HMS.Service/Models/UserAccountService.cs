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
   
    public interface IUserAccountsService
    {
        UserAccount Find(params object[] keyValues);
        void Insert(UserAccount entity);
        void Update(UserAccount entity);
        void Delete(object id);
        void Delete(UserAccount entity);
        IEnumerable<UserAccount> GetAllUserAccount();
        IEnumerable<UserAccount> GetActiveUserAccount(bool IsActive);
        UserAccount GetUserAccountByUserIdandPassword(string UserID, string Password);
        UserAccount GetUserAccount(string UserID, string Password);
        UserAccount newUserAccount();
        IEnumerable<UserAccount> GetAllUserByClient(int clientId);
        // UserAccount Add(UserAccount project);
    }
    public class UserAccountService : Service<UserAccount>, IUserAccountsService
    {
        private readonly IRepositoryAsync<UserAccount> _repository;
        private readonly IQuestionTypeService _iQuestionTypeServicee;
        public UserAccountService(

              IRepositoryAsync<UserAccount> repository
            , IQuestionTypeService iQuestionTypeServicee
            )
            : base(repository)
        {
            _repository = repository;
            _iQuestionTypeServicee = iQuestionTypeServicee;
        }
        public IEnumerable<UserAccount> GetAllUserAccount()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<UserAccount> GetActiveUserAccount(bool IsActive)
        {
            return _repository
                   .Query()
                   .Select();
        }

        public UserAccount GetUserAccountByUserIdandPassword(string UserID, string Password)
        {
            return _repository
                .Query(x => x.UserAccountsId == UserID && x.Password==Password)
                .Include(x=>x.Client)
                .Select().FirstOrDefault();
        }
        public UserAccount GetUserAccount(string UserID, string Password)
        {
            return _repository
                .Query(x => x.UserAccountsId == UserID && x.Password == Password)                
                .Select().FirstOrDefault();
        }
        public UserAccount newUserAccount()
        {
            var lstTypes = new List<KeyValuePair<int, string>>();
            _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
            {
                lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
            });

            UserAccount objUserAccount = new UserAccount();
            // objUserAccount.kvpQuestionType = lstTypes;
            return objUserAccount;
        }
        public IEnumerable<UserAccount> GetAllUserByClient(int clientId)
        {
            return _repository.Query(r=>r.ClientId==clientId)
                   .Select();
        }
    }
}
