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
   public interface IExperiencesService
   {
       Experience Find(params object[] keyValues);
       void Insert(Experience entity);
       void Update(Experience entity);
       void Delete(object id);
       void Delete(Experience entity);
       IEnumerable<Experience> GetAllExperience();
       IEnumerable<Experience> GetActiveExperience(bool IsActive);
       Experience GetExperienceById(int Id);
       Experience newExperience();
       // Experience Add(Experience project);
   }
   public class ExperienceService : Service<Experience>, IExperiencesService
   {
       private readonly IRepositoryAsync<Experience> _repository;
       private readonly IQuestionTypeService _iQuestionTypeServicee;
       public ExperienceService(

             IRepositoryAsync<Experience> repository
           , IQuestionTypeService iQuestionTypeServicee
           )
           : base(repository)
       {
           _repository = repository;
           _iQuestionTypeServicee = iQuestionTypeServicee;
       }
       public IEnumerable<Experience> GetAllExperience()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<Experience> GetActiveExperience(bool IsActive)
       {
           return _repository
                  .Query(x=>x.IsActive==IsActive)
                  .Select();
       }

       public Experience GetExperienceById(int Id)
       {
           return _repository
               .Query(x => x.Id == Id)
               .Select().FirstOrDefault();
       }
       public Experience newExperience()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
           _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
           {
               lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
           });

           Experience objExperience = new Experience();
           // objExperience.kvpQuestionType = lstTypes;
           return objExperience;
       }
   }
}
