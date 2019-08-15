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
 
   public interface INewssService
   {
       News Find(params object[] keyValues);
       void Insert(News entity);
       void Update(News entity);
       void Delete(object id);
       void Delete(News entity);
       IEnumerable<News> GetAllNews();
       IEnumerable<News> GetActiveNews(bool IsActive);
       IEnumerable<News> GetDefaultNews(bool IsDefault,bool IsActive);
       IEnumerable<News> GetArchiveNews(bool IsActive);
       News GetNewsById(int Id);
       News newNews();
       // News Add(News project);
   }
   public class NewsService : Service<News>, INewssService
   {
       private readonly IRepositoryAsync<News> _repository;
       private readonly IQuestionTypeService _iQuestionTypeServicee;
       public NewsService(

             IRepositoryAsync<News> repository
           , IQuestionTypeService iQuestionTypeServicee
           )
           : base(repository)
       {
           _repository = repository;
           _iQuestionTypeServicee = iQuestionTypeServicee;
       }
       public IEnumerable<News> GetAllNews()
       {
           return _repository.Query().Select();
       }
       public IEnumerable<News> GetActiveNews(bool IsActive)
       {
           return _repository
                  .Query(x => x.IsVisible == IsActive && x.IsArchive == false)
                  .Select().OrderByDescending(x => x.SourceDate); ;
       }
       public IEnumerable<News> GetDefaultNews(bool IsDefault, bool IsActive)
       {
           return _repository
                  .Query(x => x.IsDefault == IsDefault && x.IsVisible == false)
                  .Select();
       }
     
       public IEnumerable<News> GetArchiveNews(bool IsArchive)
       {
           return _repository
                 .Query(x => x.IsArchive == IsArchive && x.IsVisible == true)
                  .Select().OrderByDescending(x=>x.SourceDate);
       }
       public News GetNewsById(int Id)
       {
           return _repository
               .Query(x => x.NewsId == Id)
               .Select().FirstOrDefault();
       }
       public News newNews()
       {
           var lstTypes = new List<KeyValuePair<int, string>>();
           _iQuestionTypeServicee.GetAllQuestionType().ToList().ForEach(delegate(QuestionType item)
           {
               lstTypes.Add(new KeyValuePair<int, string>(item.Id, item.Type));
           });
           News objNews = new News();          
           return objNews;
       }
   }
}
