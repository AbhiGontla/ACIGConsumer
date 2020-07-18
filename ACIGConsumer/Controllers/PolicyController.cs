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
    public class PolicyController : Controller
    {
        private readonly ILogger<PolicyController> _logger;
        private PolicyHandler _policyHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;
        string langcode;
        private readonly GetLang getLang;
        public PolicyController(ILogger<PolicyController> logger,
            PolicyHandler policyHandler, IHttpContextAccessor httpContextAccessor, GetLang _getLang)
        {
            _logger = logger;
            _policyHandler = policyHandler;
            _httpContextAccessor = httpContextAccessor;
            getLang = _getLang;
            langcode = getLang.GetLanguage();
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.lang = langcode;
            var _policies = GetPoliciesById().OrderByDescending(x => x.PolicyToDate);         
            return View(_policies);
        }

        [HttpPost]
        public IActionResult Index(int? id)
        {
            return PartialView("_policyDetails");
        }

        public IActionResult Details(string id)
        {
            ViewBag.lang = langcode;
            var _policies = GetPoliciesById();
            var _policydetails = _policies.Where(c => (c.PolicyNumber == id)).FirstOrDefault();
            return View(_policydetails);
        }

        public IActionResult medicaladvice()
        {
            ViewBag.lang = langcode;
            return View();
        }
        public IActionResult medicaldetails()
        {
            ViewBag.lang = langcode;
            return View();
        }

        public List<Policies> GetPoliciesById()
        {
            return GetPoliciesByNationalId().Result;
        }
        public async Task<List<Policies>> GetPoliciesByNationalId()
        {
            string nationalId = TempData["NationalId"].ToString();
            string yob = TempData["YOB"].ToString();
            TempData.Keep("YOB");
            TempData.Keep("NationalId");
            var result = new List<Policies>();
            if (nationalId != null && yob != null)
            {
                var clsInput = new ClsInput();
                clsInput.code = "CI";
                clsInput.nationalID = nationalId;
                DateTime date = DateTime.Parse(yob);
                //DateTime date = Convert.ToDateTime(yob);
                clsInput.yearOfBirth = date.Year.ToString();
                clsInput.insPolicyNo = "";
                result = await _policyHandler.GetPoliciesByNationalId(clsInput);
            }
            return result;
        }

        public IActionResult some()
        {
            return null;
        }

    }
}
