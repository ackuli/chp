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
    public interface IContactUsService
    {
        ContactU Find(params object[] keyValues);
        void Insert(ContactU entity);
        void Update(ContactU entity);
        void Delete(object id);
        void Delete(ContactU entity);
        IEnumerable<ContactU> GetAllContactUs();
     

        ContactU GetContactUsId(int Id);
        
        // News Add(News project);
    }
    public class ContactUsService : Service<ContactU>, IContactUsService
    {
        private readonly IRepositoryAsync<ContactU> _repository;
        public ContactUsService(

             IRepositoryAsync<ContactU> repository
          
           )
           : base(repository)
       {
           _repository = repository;
           
       }

        public IEnumerable<ContactU> GetAllContactUs()
        {
            return _repository.Query().Select();
        }
        public ContactU GetContactUsId(int Id)
        {
            return _repository
                .Query(x => x.Id == Id)
                .Select().FirstOrDefault();
        }
    }
}
