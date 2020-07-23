using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Services.RequestHandler;

namespace ACIGConsumer.Controllers
{
    public class ClaimsController : Controller
    {
        private ClaimsHandler _claimsHandler;
        private readonly ILogger<ClaimsController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        string langcode;
        private readonly GetLang getLang;
        private CustomerHandler CustomerHandler;
        const string SessionShowDialog = "_showDialog";
    
        public ClaimsController(ILogger<ClaimsController> logger, IHttpContextAccessor httpContextAccessor, GetLang _getLang,
            ClaimsHandler claimsHandler,CustomerHandler customerHandler)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            getLang = _getLang;
            langcode = getLang.GetLanguage();
            _claimsHandler = claimsHandler;
            CustomerHandler = customerHandler;
        }
        public IActionResult Index()
        {
            ViewBag.lang = langcode;
            var _paidclaims = GetPaidClaimsById();           
            var claimsResponse = new ClaimsResponse();          
            claimsResponse.PaidClaims = _paidclaims.OrderByDescending(c => c.POLICY_INC).ToList();
            return View(claimsResponse);
        }

        public IActionResult ProviderPaidDetails(int id)
        {
            string Nid = TempData["NationalId"].ToString();
            TempData.Keep("NationalId");
            ViewBag.lang = langcode;
            var _paidclaims = GetPaidClaimsById();
            var _providersDetail = _paidclaims.Find(c => c.Id == id);
            var details = new ProviderClaimsDetails();
            details.paidClaims = _providersDetail;
            details.registration= CustomerHandler.GetCustomerById(Nid);
            return View(details);
        }
        public IActionResult ProviderOSDetails(int id)
        {
            string Nid = TempData["NationalId"].ToString();
            TempData.Keep("NationalId");
            ViewBag.lang = langcode;
            var _osclaims = GetOSClaimsById();
            var _osclaimDetail = _osclaims.Find(c => c.Id == id);
            var details = new ProviderOSClaimsDetails();
            details.OSClaims = _osclaimDetail;
            details.registration = CustomerHandler.GetCustomerById(Nid);
            return View(details);
        }
        public IActionResult ReimbursmentClaims()
        {
            ViewBag.lang = langcode;
            var _reimclaims = GetReimClaimsByClientId().OrderByDescending(c => c.RequestDate).ToList();
            string showdialog = HttpContext.Session.GetString(SessionShowDialog);
            string status = "";
            if (showdialog !=null)
            {
                status = HttpContext.Session.GetString(SessionShowDialog);
            }
            ViewBag.showdialog = status;
            return View(_reimclaims);
        }
        public IActionResult ReImClaimDetais(string id)
        {
            string Nid = TempData["NationalId"].ToString();
            TempData.Keep("NationalId");
            ViewBag.lang = langcode;         
            var clamDetails = new ReClaimsDetails();
            clamDetails.RequestCreateDTO= GetReimClaimDetailsById(id);
            clamDetails.registration = CustomerHandler.GetCustomerById(Nid);
            clamDetails._claimstypes = GetClaimTypesViewModel();
            clamDetails._bankNames = GetBankViewModel();
            ViewBag.RequestStatus = clamDetails.RequestCreateDTO.RequestStatusName;
            //ViewBag.RequestStatus = GetRequestStatus(clamDetails.RequestCreateDTO.RequestStatusLogList);
            return View(clamDetails);
        }

        private string GetRequestStatus(List<RequestStatusLogList> requestStatusLogList)
        {
            string status = "";
            var requestlist = requestStatusLogList.OrderByDescending(c=>c.CreateDate).FirstOrDefault();
            status = requestlist.RequestStatusName.ToString();
            return status;
        }

        public IActionResult AddClaim()
        {
            string Nid = TempData["NationalId"].ToString();
            TempData.Keep("NationalId");
            ViewBag.lang = langcode;
            var userdetails = CustomerHandler.GetCustomerById(Nid);
            ViewBag.MemberName = userdetails.MemberName;
            var _viewm = new AddClaimViewModel();
            _viewm._claimstypes = GetClaimTypesViewModel();
            _viewm._bankNames = GetBankViewModel();
            return View(_viewm);
        }
        [HttpPost]
        public IActionResult AddClaim(AddClaimViewModel createDTO)
        {
            List<IFormFile> uploadedFiles = createDTO.FilesUploaded;
            if (!ModelState.IsValid)
            {
                ViewBag.lang = langcode;
                createDTO._claimstypes = GetClaimTypesViewModel();
                createDTO._bankNames = GetBankViewModel();
                createDTO.FilesUploaded = uploadedFiles;
                return View(createDTO);
               
            }
            else
            {
                ViewBag.lang = langcode;
                createDTO.NationalId= TempData["NationalId"].ToString();
                TempData.Keep("NationalId");
                var res=AddClaimRequest(createDTO);
               
                if(res == "true")
                {
                    HttpContext.Session.SetString(SessionShowDialog, "true");
                }
                else
                {
                    HttpContext.Session.SetString(SessionShowDialog, "false");
                }
                
                return RedirectToAction("ReimbursmentClaims","Claims",new { lang="en"});
            }
            
          
        }

        public IActionResult GetOSClaims()
        {
            ViewBag.lang = langcode;
            var _osClaims = GetOSClaimsById();
            var claimsResponse = new ClaimsResponse();
            claimsResponse.OSClaims = _osClaims.OrderByDescending(c => c.POLICY_INC).ToList();
            return View(claimsResponse);
        }
        public List<PaidClaims> GetPaidClaimsById()
        {
            return GetPaidClaimsByNationalId().Result;
        }
        public async Task<List<PaidClaims>> GetPaidClaimsByNationalId()
        {
            string nationalId = TempData["NationalId"].ToString();
            string yob = TempData["YOB"].ToString();
            TempData.Keep("YOB");
            TempData.Keep("NationalId");
            var result = new List<PaidClaims>();
            if (nationalId != null && yob != null)
            {
                var clsInput = new ClsInput();
                clsInput.code = "";
                clsInput.nationalID = nationalId;
                DateTime date = Convert.ToDateTime(yob);
                clsInput.yearOfBirth = date.Year.ToString();
                clsInput.insPolicyNo = "";
                result = await _claimsHandler.GetPaidClaimsByNationalId(clsInput);

            }

            return result;
        }
        public List<OSClaims> GetOSClaimsById()
        {
            return GetOSClaimsByNationalId().Result;
        }
        public async Task<List<OSClaims>> GetOSClaimsByNationalId()
        {
            string nationalId = TempData["NationalId"].ToString();
            string yob = TempData["YOB"].ToString();
            TempData.Keep("YOB");
            TempData.Keep("NationalId");
            var result = new List<OSClaims>();
            if (nationalId != null && yob != null)
            {
                var clsInput = new ClsInput();
                clsInput.code = "";
                clsInput.nationalID = nationalId;
                DateTime date = Convert.ToDateTime(yob);
                clsInput.yearOfBirth = date.Year.ToString();
                clsInput.insPolicyNo = "";
                result = await _claimsHandler.GetOSClaimsByNationalId(clsInput);

            }
            return result;
        }

        public List<ReImClaims> GetReimClaimsByClientId()
        {
            return GetReClaimsByClientId().Result;
        }
        public async Task<List<ReImClaims>> GetReClaimsByClientId()
        {
            string nationalId = TempData["NationalId"].ToString();
            string yob = TempData["YOB"].ToString();
            TempData.Keep("YOB");
            TempData.Keep("NationalId");
            var result = new List<ReImClaims>();
            if (nationalId != null)
            {
                result = await _claimsHandler.GetReImClaimsByClientId(nationalId);
            }
            return result;
        }
        public RequestCreateDTO GetReimClaimDetailsById(string id)
        {
            return GetReImDetailsById(id).Result;
        }
        public async Task<RequestCreateDTO> GetReImDetailsById(string id)
        {
            string nationalId = TempData["NationalId"].ToString();
            string yob = TempData["YOB"].ToString();
            TempData.Keep("YOB");
            TempData.Keep("NationalId");
            var result = new RequestCreateDTO();
            if (nationalId != null)
            {
                result = await _claimsHandler.GetReImClaimDetailsById(id);
            }
            return result;
        }

        public List<MRClaimType> GetClaimTypes()
        {
            return GetAllClaimTypes().Result;
        }
        public async Task<List<MRClaimType>> GetAllClaimTypes()
        {

            return await _claimsHandler.GetClaimsTypes();

        }
        public List<BankMaster> GetBankMasters()
        {
            return GetAllBanks().Result;
        }
        public async Task<List<BankMaster>> GetAllBanks()
        {

            return await _claimsHandler.GetBankNames();

        }

        private List<SelectListItem> GetClaimTypesViewModel()
        {
            List<SelectListItem> claimtypes = null;
            var clmtypes = GetClaimTypes();
            claimtypes = clmtypes.ConvertAll(a =>
              {
                  return new SelectListItem()
                  {
                      Text = a.ClaimTypeName.ToString(),
                      Value = a.ClaimTypeName.ToString(),
                      Selected = false
                  };
              });

            return claimtypes;
        }

        private List<SelectListItem> GetBankViewModel()
        {
            List<SelectListItem> banks = null;

            banks = GetBankMasters().ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.BankNameEnglish.ToString(),
                    Value = a.BankNameEnglish.ToString(),
                    Selected = false
                };
            });

            return banks;
        }


        public string AddClaimRequest(AddClaimViewModel _clm)
        {
            return AddClaimReq(_clm).Result;
        }
        public async Task<string> AddClaimReq(AddClaimViewModel _clm)
        {
            string nationalId = TempData["NationalId"].ToString();
            _clm.ClientDTO.IDNumber = nationalId;
            return await _claimsHandler.AddClaimRequest(_clm);

        }
        [HttpPost]
        public IActionResult UpdateClaim(ReClaimsDetails _claimdetails)
        {
            var res = UpdateClaimRequest(_claimdetails);
            if (res.ToUpper() == "TRUE")
            {
                if (res == "true")
                {
                    HttpContext.Session.SetString(SessionShowDialog, "updatesuccess");
                }
                else
                {
                    HttpContext.Session.SetString(SessionShowDialog, "updatefailed");
                }
                return RedirectToAction("ReimbursmentClaims", "Claims", new { lang = "en" });
            }
            else
            {
                return View();
            }
         
        }

        public string UpdateClaimRequest(ReClaimsDetails _clm)
        {
            return UpdateClaimReq(_clm).Result;
        }
        public async Task<string> UpdateClaimReq(ReClaimsDetails _clm)
        {          
            return await _claimsHandler.UpdateClaimRequest(_clm);
        }
    }
}
