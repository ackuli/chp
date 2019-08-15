using HMS.Entities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Models
{
    
    public interface IContentService
    {
        Content Find(params object[] keyValues);
        void Insert(Content entity);
        void Update(Content entity);
        void Delete(object id);
        void Delete(Content entity);
        IEnumerable<Content> GetContent(string FREETEXT);       
        Content GetContentById(int Id);

    }
    public class ContentService : Service<Content>, IContentService
    {
        private readonly IRepositoryAsync<Content> _repository;
        private readonly IQuestionTypeService _iQuestionTypeServicee;
        private readonly IStoredProcedures _iStoredProcedures;
        public ContentService(

              IRepositoryAsync<Content> repository
            , IQuestionTypeService iQuestionTypeServicee
            ,IStoredProcedures iStoredProcedures
            )
            : base(repository)
        {
            _repository = repository;
            _iQuestionTypeServicee = iQuestionTypeServicee;
            _iStoredProcedures=iStoredProcedures;
        }
        public IEnumerable<Content> GetContent(string FREETEXT)
        {           
            return _iStoredProcedures.GetContent(FREETEXT);
        }
       
        public Content GetContentById(int Id)
        {
            return _repository
                .Query(x => x.ContentId == Id)
                .Select().FirstOrDefault();
        }

    }
}
