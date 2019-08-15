using HMS.Service.Models;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    public class ContentController : Controller
    {
          private readonly IUnitOfWork _unitOfWork;
        private readonly IContentService _iContentService;

        public ContentController(IUnitOfWork unitOfWork, IContentService iContentService)
        {
            _unitOfWork = unitOfWork;
            _iContentService = iContentService;
        }
        public ActionResult FindContent(string freetext)
        {
          var   content=_iContentService.GetContent(freetext);

          return View(content);
        }

      
    }
}
