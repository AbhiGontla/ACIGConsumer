using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACIGConsumer.Models;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.RequestHandler;

namespace ACIGConsumer.Controllers
{


    public class TOBController : Controller
    {

        private TOBHandler _tobHandler;
        private readonly IOptions<ApplConfig> appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        string langcode;
        private readonly GetLang getLang;

        public TOBController(IOptions<ApplConfig> _config, TOBHandler tobHandler,IHttpContextAccessor httpContextAccessor, GetLang _getLang)
        {
           
            appSettings = _config;
            _tobHandler = tobHandler;
            _httpContextAccessor = httpContextAccessor;
            getLang = _getLang;
            langcode = getLang.GetLanguage();
        }
        public IActionResult Index()
        {
            ViewBag.lang = langcode;
            string nationalId = TempData["NationalId"].ToString();
            string yob = TempData["YOB"].ToString();
            TempData.Keep("YOB");
            TempData.Keep("NationalId");
            var _tobs = _tobHandler.GetTOBById(nationalId, yob);
            return View(_tobs);
        }
    }
}
