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

namespace ACIGConsumer.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;
        string langcode;        
        private readonly GetLang getLang;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, GetLang _getLang)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            getLang = _getLang;
            langcode=getLang.GetLanguage();
        }

        public IActionResult Index(Registration _data)
        {
            //ViewBag.lang = HttpContext.Session.GetString(Langcode);   
            ViewBag.lang = langcode;
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

        public void GetApprovals()
        {
          
        }
       
    }
}
