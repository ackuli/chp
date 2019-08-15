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
    public interface IScholareService
    {
        Scholare Find(params object[] keyValues);
        void Insert(Scholare entity);
        void Update(Scholare entity);
        void Delete(object id);
        void Delete(Scholare entity);
        IEnumerable<Scholare> GetAllScholare();
        IEnumerable<Scholare> GetActiveScholare(bool IsActive);
        Scholare GetScholareById(int Id);
    }
    public class ScholareService : Service<Scholare>, IScholareService
    {
        private readonly IRepositoryAsync<Scholare> _repository;

        public ScholareService(

              IRepositoryAsync<Scholare> repository
            )
            : base(repository)
        {
            _repository = repository;
        }
        public IEnumerable<Scholare> GetAllScholare()
        {
            return _repository.Query().Select();
        }
        public IEnumerable<Scholare> GetActiveScholare(bool IsActive)
        {
            return _repository
                   .Query(r=>r.IsActive)
                   .Select();
        }
        public Scholare GetScholareById(int Id)
        {
            return _repository
                .Query(x => x.ScholarId == Id)
                .Select().FirstOrDefault();
        }

    }
}
