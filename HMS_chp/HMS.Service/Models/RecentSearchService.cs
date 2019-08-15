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
      
   public interface IRecentSearchsService
   {
       RecentSearch Find(params object[] keyValues);
       void Insert(RecentSearch entity);
       void Update(RecentSearch entity);
       void Delete(object id);
       void Delete(RecentSearch entity);
       IEnumerable<RecentSearch> GetAllRecentSearch();
       IEnumerable<RecentSearch> GetActiveRecentSearch(bool IsActive);
       RecentSearch GetRecentSearchById(int Id);
       RecentSearch newRecentSearch();
       // RecentSearch Add(RecentSearch project);
   }
   public class RecentSearchService : Service<RecentSearch>, IRecentSearchsService
   {
       private readonly IRepositoryAsync<RecentSearch> _repository;
       private readonly IQuestionTypeService _iQuestionTypeServicee;
       public RecentSearchService(

             IRepositoryAsync<RecentSearch> repository
           , IQuestionTypeService iQuestionTypeServicee
           )
           : base(repository)
       {
           _repository = repository;
           _iQuestionTypeServicee = iQuestionTypeServicee;
       }
       public IEnumerable<RecentSearch> GetAllRecentSearch()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<RecentSearch> GetActiveRecentSearch(bool IsActive)
       {
           return _repository
                  .Query()
                  .Select();
       }

       public RecentSearch GetRecentSearchById(int Id)
       {
           return _repository
               .Query(x => x.Id == Id)
               .Select().FirstOrDefault();
       }
       public RecentSearch newRecentSearch()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
           _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
           {
               lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
           });

           RecentSearch objRecentSearch = new RecentSearch();
           // objRecentSearch.kvpQuestionType = lstTypes;
           return objRecentSearch;
       }
   }
}
