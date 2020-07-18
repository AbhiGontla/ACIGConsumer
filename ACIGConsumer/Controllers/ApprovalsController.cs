using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACIGConsumer.Models;
using Core;
using Core.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using Services.RequestHandler;

namespace ACIGConsumer.Controllers
{
    public class ApprovalsController : Controller
    {
        private readonly ILogger<ApprovalsController> _logger;
        private ApprovalsHandler _approvalsHandler;
        private readonly IOptions<ApplConfig> appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        string langcode;
        private readonly GetLang getLang;
        public ApprovalsController(ILogger<ApprovalsController> logger,
            IOptions<ApplConfig> _config, ApprovalsHandler approvalsHandler, IHttpContextAccessor httpContextAccessor, GetLang _getLang)
        {
            _logger = logger;
            appSettings = _config;
            _approvalsHandler = approvalsHandler;
            _httpContextAccessor = httpContextAccessor;
            getLang = _getLang;
            langcode = getLang.GetLanguage();
        }
        public IActionResult Index()
        {
            ViewBag.lang = langcode;
            var _approvals = GetApprovById().OrderByDescending(x => x.CL_DATEOT);
       
            return View(_approvals);
        }
        public IActionResult test()
        {
            return View();
        }


        public List<Approvals> GetApprovById()
        {
            return GetApprovalsByNationalId().Result;
        }
        public async Task<List<Approvals>> GetApprovalsByNationalId()
        {
            string nationalId = TempData["NationalId"].ToString();
            string yob = TempData["YOB"].ToString();
            TempData.Keep("YOB");
            TempData.Keep("NationalId");
            var result = new List<Approvals>();
            if (nationalId != null && yob != null)
            {
                var clsInput = new ClsInput();
                clsInput.code = "CI";
                clsInput.nationalID = nationalId;
                DateTime date = Convert.ToDateTime(yob);
                clsInput.yearOfBirth = date.Year.ToString();
                clsInput.insPolicyNo = "";
                result = await _approvalsHandler.GetApprovalsByNationalId(clsInput);
            }           
            return result;
        }

        
    }
}
