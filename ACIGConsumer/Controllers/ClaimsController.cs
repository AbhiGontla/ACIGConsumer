using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ClaimsController(ILogger<ClaimsController> logger, IHttpContextAccessor httpContextAccessor, GetLang _getLang,
            ClaimsHandler claimsHandler)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            getLang = _getLang;
            langcode = getLang.GetLanguage();
            _claimsHandler = claimsHandler;
        }
        public IActionResult Index()
        {
            ViewBag.lang = langcode;
            var _paidclaims = GetPaidClaimsById();
           
            var _osClaims = GetOSClaimsById();
            var claimsResponse = new ClaimsResponse();
            claimsResponse.OSClaims = _osClaims;
            claimsResponse.PaidClaims = _paidclaims;
            return View(claimsResponse);
        }
      
        public IActionResult ReimbursmentClaims()
        {
            ViewBag.lang = langcode;
            var _reimclaims = GetReimClaimsByClientId();
            return View(_reimclaims);
        }
        public IActionResult ReImClaimDetais(string id)
        {
            ViewBag.lang = langcode;
            var _claimsdetails = GetReimClaimDetailsById(id);
            return View(_claimsdetails);
        }
        public IActionResult AddClaim()
        {
            ViewBag.lang = langcode;
            return View();
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
    }
}
