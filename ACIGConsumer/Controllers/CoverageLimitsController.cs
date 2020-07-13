using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.RequestHandler;

namespace ACIGConsumer.Controllers
{
    public class CoverageLimitsController : Controller
    {
        private CoverageBalanceHandler _coverageHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;
        string langcode;
        private readonly GetLang getLang;
        public CoverageLimitsController(CoverageBalanceHandler coverageHandler, IHttpContextAccessor httpContextAccessor, GetLang _getLang)
        {           
            _coverageHandler = coverageHandler;
            _httpContextAccessor = httpContextAccessor;
            getLang = _getLang;
            langcode = getLang.GetLanguage();
        }
        public IActionResult Index()
        {
            ViewBag.lang = langcode;
            var _coverages = GetCoveragesById();
            return View(_coverages);
        }

        public IActionResult Details(int id)
        {
            ViewBag.lang = langcode;
            var _coverages = GetCoveragesById();
            var _coverageDetails = _coverages.Where(c => (c.Id == id));
            return View(_coverageDetails);
        }

        public List<CoverageBalance> GetCoveragesById()
        {
            return GetCoveragesByNationalId().Result;
        }
        public async Task<List<CoverageBalance>> GetCoveragesByNationalId()
        {
            string nationalId = TempData["NationalId"].ToString();
            string yob = TempData["YOB"].ToString();
            TempData.Keep("YOB");
            TempData.Keep("NationalId");
            var result = new List<CoverageBalance>();
            if (nationalId != null && yob != null)
            {
                var clsInput = new ClsInput();
                clsInput.code = "";
                clsInput.nationalID = nationalId;
                DateTime date = Convert.ToDateTime(yob);
                clsInput.yearOfBirth = date.Year.ToString();
                clsInput.insPolicyNo = "";
                result = await _coverageHandler.GetCoveragesByNationalId(clsInput);
            }
            return result;
        }
    }
}
