using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ACIGConsumer.Controllers
{
    public class TestController : Controller
    {
        string langcode;
        private readonly GetLang getLang;
        private ICustomerService _customerService;

        const string SessionNId = "_Name";
        const string SessionDOB = "_Age";
        public TestController(GetLang _getLang, ICustomerService customerService)
        {
            getLang = _getLang;
            langcode = getLang.GetLanguage();
            _customerService = customerService;
        }
        public IActionResult Register()
        {
            ViewBag.lang = langcode;
            return View();
        }

        public IActionResult VerifyDetails(string nid,DateTime dob)
        {
            ViewBag.lang = langcode;
            if(nid !=null && dob != null)
            {
                
                setsession(nid, dob);
                return Json(new { success = true });
            }
            else
            {
                return View();
            }     
        }

        public void setsession(string nid,DateTime dob)
        {
            string dt = dob.ToString("yyyy-MM-dd");
            HttpContext.Session.SetString(SessionNId, nid);
            HttpContext.Session.SetString(SessionDOB, dt);
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
        public IActionResult RegisterUser(string enterpin, string confirmpin)
        {
            string status = "false";
            try
            {
                
                var nationalId=HttpContext.Session.GetString(SessionNId);
                var dateofbirth=HttpContext.Session.GetString(SessionDOB);
                Registration _userdetails = new Registration();
                _userdetails.Iqama_NationalID = nationalId;
                _userdetails.DOB = dateofbirth;
                _userdetails.CreatePin = enterpin;
                _userdetails.ConfirmPin = confirmpin;
                _customerService.Insert(_userdetails);
                TempData["NationalId"] = nationalId;
                DateTime dt = Convert.ToDateTime(dateofbirth);

                //Know the year

                int year = dt.Year;
                TempData["YOB"] = year;
                TempData.Keep("YOB");
                TempData.Keep("NationalId");
                status = "true";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (status == "false")
            {
                return Json(new { success = false, responseText = "User Registration Failed." });
            }
            else
            {
                return Json(new { success = true, responseText = "User Registration Success." });
            }

        }

    }
}
