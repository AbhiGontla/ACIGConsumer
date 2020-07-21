using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ACIGConsumer.Models;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using Microsoft.AspNetCore.Razor.Language;
using Core.Domain;
using Microsoft.AspNetCore.Authorization;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Core;
using Services.RequestHandler;

namespace ACIGConsumer.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;
        string langcode;        
        private readonly GetLang getLang;
        private PolicyHandler policyHandler ;
        private ApprovalsHandler ApprovalsHandler;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, 
            GetLang _getLang, PolicyHandler policy, ApprovalsHandler _approvalsHandler)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            getLang = _getLang;
            langcode=getLang.GetLanguage();
            policyHandler = policy;
            ApprovalsHandler = _approvalsHandler;
        }

        public IActionResult Index(Registration _data)
        {
            string nationalId = TempData["NationalId"].ToString();
            string yob = TempData["YOB"].ToString();
            TempData.Keep("YOB");
            TempData.Keep("NationalId");         
            ViewBag.lang = langcode;
            ViewBag.Policies = policyHandler.GetPoliciesById(nationalId,yob).OrderByDescending(x => x.PolicyToDate).FirstOrDefault();
            ViewBag.Approvals = ApprovalsHandler.GetApprovById(nationalId, yob).OrderByDescending(x => x.CL_DATEOT).FirstOrDefault();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
       
    }
}
