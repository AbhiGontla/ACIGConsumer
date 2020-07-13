using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace ACIGConsumer.Controllers
{
    public class TestController : Controller
    {
        string langcode;
        private readonly GetLang getLang;
        public TestController(GetLang _getLang)
        {
            getLang = _getLang;
            langcode = getLang.GetLanguage();
        }
        public IActionResult Register()
        {
            ViewBag.lang = langcode;
            return View();
        }

        public IActionResult VerifyDetails(string nid,string dob)
        {
            ViewBag.lang = langcode;
            if(nid !=null && dob != null)
            {
                TempData["nId"] = nid;
                TempData["dob"] = dob;
                TempData.Keep("nId");
                TempData.Keep("dob");
                return Json(new { success = true });
            }
            else
            {
                return View();
            }         
           
        }
        public IActionResult VerifyOTP()
        {
            ViewBag.lang = langcode;
            return View();
        }
        public IActionResult CreatePin()
        {
            ViewBag.lang = langcode;
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.lang = langcode;
            return View();
        }


    }
}
