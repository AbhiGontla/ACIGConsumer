using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.RequestHandler;

namespace ACIGConsumer.Controllers
{
    public class TestController : Controller
    {
        string langcode;
        private readonly GetLang getLang;
        private ICustomerService _customerService;
        private CustomerHandler CustomerHandler;

        const string SessionNId = "_Name";
        const string SessionDOB = "_Age";
        public TestController(GetLang _getLang, ICustomerService customerService,CustomerHandler customerHandler)
        {
            getLang = _getLang;
            langcode = getLang.GetLanguage();
            _customerService = customerService;
            CustomerHandler = customerHandler;
        }
        public IActionResult Register()
        {
            ViewBag.lang = langcode;
            return View();
        }

        public IActionResult VerifyDetails(string nid, DateTime dob)
        {
            ViewBag.lang = langcode;
            if (nid != null && dob != null)
            {
                
                var result=ValidateIDByNIC(nid,"");
                if (result ==true)
                {
                    var userexist = ValidateUser(nid,dob);
                    if(userexist != true) {
                        setsession(nid, dob);
                        return Json(new { success = true });
                    }
                    else
                    {
                        return Json(new { success = false, responseText = "User Already Exists,Please Login." });
                    }
                    
                }
                else
                {
                    return Json(new { success = false, responseText = "Invalid Credentials." });
                }
                
               
            }
            else
            {
                return View();
            }
        }

        public void setsession(string nid, DateTime dob)
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

                var nationalId = HttpContext.Session.GetString(SessionNId);
                var dateofbirth = HttpContext.Session.GetString(SessionDOB);
                Registration _userdetails = new Registration();
                _userdetails.Iqama_NationalID = nationalId;
                _userdetails.DOB = dateofbirth;
                _userdetails.CreatePin = enterpin;
                _userdetails.ConfirmPin = confirmpin;
                _customerService.Insert(_userdetails);
                TempData["NationalId"] = nationalId;
                DateTime dt = Convert.ToDateTime(dateofbirth);
                TempData["YOB"] = dateofbirth;
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


        public static bool ValidateIDByNIC(string IDNumber, string idType)
        {
            var _output = true;
            try
            {
                if (IDNumber.Length != 10)
                {
                    return false;
                }

                int nSum = 0;
                string lastDigit = "";
                int nDigit = 0;

                for (int i = 0; i < 9; i++)
                {
                    nDigit = Convert.ToByte(IDNumber[i]) - 48;
                    if (i % 2 == 0) // If Odd position digit double it
                    {
                        if ((nDigit * 2) > 9)
                            nSum += Convert.ToByte(((nDigit * 2).ToString().Substring(0, 1))) + Convert.ToByte(((nDigit * 2).ToString().Substring(1, 1)));
                        else
                            nSum += nDigit * 2;
                    }
                    else
                        nSum += nDigit;
                }

                lastDigit = (nSum % 10).ToString();
                if (lastDigit != "0")
                {
                    lastDigit = ((10 - (Convert.ToByte(lastDigit)))).ToString();
                }

                if (lastDigit == IDNumber.Substring(9, 1))
                    _output = true;
                else
                    _output = false;
            }
            catch (Exception ex)
            {
                _output = false;
            }
            return _output;
        }

        public  bool ValidateUser(string nid,DateTime dob)
        {
            bool status = true;
            try
            {
                string dt = dob.ToString("yyyy-MM-dd");
                var usersList = CustomerHandler.GetAllUsers();
                var userdetails = usersList.Result.Where(c => (c.Iqama_NationalID == nid) && (c.DOB == dt)).FirstOrDefault();
                if (userdetails != null)
                {
                    return status;
                }
                else
                {
                    status = false;
                }
            }catch(Exception ex)
            {
                ex.Message.ToString();
            }
            return status;
        }
       
    }
}
