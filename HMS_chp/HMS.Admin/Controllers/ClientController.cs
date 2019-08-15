using HMS.Entities.Models;
using HMS.Service.Models;
using HMS.Admin.Utility;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using System.IO;
namespace HMS.Admin.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _IClientService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBinaryObjectService _iBinaryObjectService;
        public ClientController(IClientService IClientService, IUnitOfWork unitOfWork,IBinaryObjectService iBinaryObjectService

                        )
        {
            _IClientService = IClientService;
            _iBinaryObjectService = iBinaryObjectService;
            _unitOfWork = unitOfWork;

        }
        public ActionResult ClientList(int? page, string searchItem)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int PAGE_SIZE = 6;
            var ClientId = HMS.Admin.MvcApplication.GolbalSession.gblSession.ClientId;
            var roleid = HMS.Admin.MvcApplication.GolbalSession.gblSession.RoleId;
            var ClientList = new List<Client>();
            if (roleid == "1")//Admin
            {
              IList<HMS.Entities.Models.Client>  ClientList1 = _IClientService.GetAllClient().ToList();
             ClientList1= ClientList1.ToPagedList(currentPageIndex, PAGE_SIZE);
                    return View(ClientList1);
            }
            else if (roleid == "3")//Client
            {
                ClientList = _IClientService.GetClientListById(ClientId).ToList();
            }

            return View(ClientList);
           
        }

        // GET: ClientInformation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientInformation/Create

        [CustomActionFilterAttribute]
        public ActionResult ClientCreate()
        {
            var client = _IClientService.newClient();
            return View(client);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientCreate([Bind(Include = "ClientId,ClientName,IsHajjApproval,HajjApprovalLicienceNumberNo,IsUmarhApproval,UmarhApprovalLicienceNumberNo,Address,Tellandline,TelMobile,Email , Website , YearEstablished  , IsApprovedbySaudiHajjMinistry ,MinistryApprovalNumber ,Approvedfor , ATOLApproved , ATOLLicense , IATANo , CompanyRegistrationNumber , Remarks , SetBy , SetDate , LastUpdateDate")] Client client)
        {
            client.Setdate = DateTime.Now;
            client.LastUpdateDate = DateTime.Now;
             client.SetBy = HMS.Admin.MvcApplication.GolbalSession.gblSession.UserId;
            try
            {
                _IClientService.Insert(client);
                _unitOfWork.SaveChanges();
            }
            catch{
                return View();
            }                        
            return View();
        }
        // GET: ClientInformation/Edit/5
        
        [CustomActionFilterAttribute]
        public ActionResult Editclient(int id)
        {
            var client=_IClientService.Find(id);
            return View(client);
        }
        public byte[] ConvertsToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        // POST: ClientInformation/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [CustomActionFilterAttribute]
        public ActionResult Editclient(Client client, HttpPostedFileBase file)
        {
            client.Setdate = DateTime.Now;
            client.LastUpdateDate = DateTime.Now;
            client.SetBy = HMS.Admin.MvcApplication.GolbalSession.gblSession.UserId;
            try
            {
                var objbinaryObject = new HMS.Entities.Models.BinaryObject();
                if (file != null)
                {
                    objbinaryObject = _iBinaryObjectService.GetBinaryObjectById(client.ClientId,9);
                    if (objbinaryObject == null)
                    {
                        objbinaryObject = new HMS.Entities.Models.BinaryObject(); ;
                        var imagebyte = ConvertsToBytes(file);
                        objbinaryObject.RefObjectKey = client.ClientId;                       
                        objbinaryObject.Object = imagebyte;
                        objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.AgentLogo;
                        objbinaryObject.Name = file.FileName;
                        objbinaryObject.Extension = file.ContentType;
                        _iBinaryObjectService.Insert(objbinaryObject);
                    }
                    else
                    {

                        var imagebyte = ConvertsToBytes(file);
                        objbinaryObject.Object = imagebyte;
                        objbinaryObject.RefObjectTypeId = (int)utility.binaryObjectTypes.News;
                        objbinaryObject.Name = file.FileName;
                        objbinaryObject.Extension = file.ContentType;
                        _iBinaryObjectService.Update(objbinaryObject);
                    }

                    _unitOfWork.SaveChanges();


                }
                
                _IClientService.Update(client);
                _unitOfWork.SaveChanges();
                return RedirectToAction("ClientList");
            }
            catch
            {
                return View();
            }
        }
        // GET: ClientInformation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
