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
 
    public interface IDistanceUnitService
    {
        DistanceUnit Find(params object[] keyValues);
        void Insert(DistanceUnit entity);
        void Update(DistanceUnit entity);
        void Delete(object id);
        void Delete(DistanceUnit entity);
        IEnumerable<DistanceUnit> GetAllDistanceUnits();
        DistanceUnit GetDistanceUnitsId(int Id);
       
    }
    public class DistanceUnitsService : Service<DistanceUnit>, IDistanceUnitService
    {
        private readonly IRepositoryAsync<DistanceUnit> _repository;
        public DistanceUnitsService(

             IRepositoryAsync<DistanceUnit> repository

           )
            : base(repository)
        {
            _repository = repository;

        }

        public IEnumerable<DistanceUnit> GetAllDistanceUnits()
        {
            return _repository.Query().Select();
        }
        public DistanceUnit GetDistanceUnitsId(int Id)
        {
            return _repository
                .Query(x => x.DistanceUnitId == Id)
                .Select().FirstOrDefault();
        }
    }
}
