using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace ACIGConsumer.Controllers
{
    public class LimitationsController : Controller
    {
        string langcode;
        private readonly GetLang getLang;
        public LimitationsController(GetLang _getLang)
        {
            getLang = _getLang;
            langcode = getLang.GetLanguage();
        }
        public IActionResult Index()
        {
            ViewBag.lang = langcode;
            return View();
        }
    }
}
