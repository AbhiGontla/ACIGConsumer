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
    public class ProvidersController : Controller
    {
        private ProvidersHandler _providersHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;
        string langcode;
        private readonly GetLang getLang;
        public ProvidersController(ProvidersHandler providersHandler, IHttpContextAccessor httpContextAccessor, GetLang _getLang)
        {
            _providersHandler = providersHandler;
            _httpContextAccessor = httpContextAccessor;
            getLang = _getLang;
            langcode = getLang.GetLanguage();
        }
        public IActionResult Index()
        {
            var _providers = GetProvidersById();
            ViewBag.lang = langcode;
            return View(_providers);
        }
        public IActionResult Details(string id)
        {
            var _providers = GetProvidersById();
            var _provdetails = _providers.Where(c => c.ProviderNumber == id);
            ViewBag.lang = langcode;
            return View(_provdetails);
        }

        public List<Providers> GetProvidersById()
        {
            return GetProvidersByNationalId().Result;
        }
        public async Task<List<Providers>> GetProvidersByNationalId()
        {
            string nationalId = TempData["NationalId"].ToString();
            string yob = TempData["YOB"].ToString();
            TempData.Keep("YOB");
            TempData.Keep("NationalId");
            var result = new List<Providers>();
            if (nationalId != null && yob != null)
            {
                var clsInput = new ClsInput();
                clsInput.code = "CI";
                clsInput.nationalID = nationalId;
                DateTime date = Convert.ToDateTime(yob);
                clsInput.yearOfBirth = date.Year.ToString();
                clsInput.insPolicyNo = "";
                result = await _providersHandler.GetProvidersByNationalId(clsInput);
            }
            return result;
        }
    }
}
