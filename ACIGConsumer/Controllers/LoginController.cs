using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ACIGConsumer.Models;
using Core;
using Core.Domain;
using Core.Sms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Interfaces;

namespace ACIGConsumer.Controllers
{
    public class LoginController : Controller
    {
        private  ICustomerService _customerService;
        private readonly IOptions<ApplConfig> appSettings;
        string langcode;
        private readonly GetLang getLang;
        public LoginController(ICustomerService customerService, IOptions<ApplConfig> _config, GetLang _getLang)
        {
            _customerService = customerService;
            appSettings = _config;
            getLang = _getLang;
            langcode = getLang.GetLanguage();
        }
        public IActionResult Index()
        {
            string link = "https://localhost:44310/Test/Login?lang=en";
            return Redirect(link);
        }
        public IActionResult sendsms()
        {
            var otp = GenerateRandomNo();
            string url = appSettings.Value.SmsConfig.url;
            string uname = appSettings.Value.SmsConfig.userName;
            string pwd = appSettings.Value.SmsConfig.password;
            string sender = appSettings.Value.SmsConfig.senderName;
            string mobilenumber = "966508095931";
            string message = "Dear Customer,Your One Time Password(OTP):" + otp;
            SmsRequest request = new SmsRequest();
            var response=request.SmsHandler(mobilenumber, message);

            if (response.ToString() == "Success")
            {
                TempData["SentOTP"] = otp;
                TempData.Keep("SentOTP");
                return Json(new { success = true, responseText = "Sending OTP Success.", sentotp = otp });
                
            }
            else
            {
                return Json(new { success = false, responseText = "Sending OTP Failed." });
            }           

        }
     
        //Generate RandomNo
        public int GenerateRandomNo()
        {
            Random _rdm = new Random();
            int _min = 1000;
            int _max = 9999;
            return _rdm.Next(_min, _max);
        }

        [HttpGet]
        public IActionResult ValidateUser(string nid, string pin)
        {            
            Registration Item = _customerService.ValidateCustomer(nid, pin);

        

            if (Item == null)
            {
                return Json(new { success = false, responseText = "Login Failed." }); 
            }
            else
            {
                //second request, get value marking it from deletion
                TempData["NationalId"] = Item.Iqama_NationalID;
                TempData["YOB"] = Item.DOB;
                //later on decide to keep it
                TempData.Keep("YOB");
                TempData.Keep("NationalId");
                return Json(new { success = true, responseText = "Login Success." });
            }
        }
       
        public IActionResult RegisterUser(string enterpin, string confirmpin)
        {
            string status = "false";
            try
            {
                Registration _userdetails = new Registration();
                _userdetails.Iqama_NationalID = TempData["nId"].ToString();                
                _userdetails.DOB = TempData["dob"].ToString();
                _userdetails.CreatePin = enterpin;
                _userdetails.ConfirmPin = confirmpin;
                _customerService.Insert(_userdetails);
                TempData["NationalId"] = _userdetails.Iqama_NationalID;
                DateTime dt = Convert.ToDateTime(TempData["dob"].ToString());

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



        public IActionResult Logout()
        {
            string link = "https://localhost:44310/Test/Login?lang=en";
            return Redirect(link);
        }

        public IActionResult validateOTP(string otp)
        {
            TempData["SentOTP"] = otp;
            TempData.Keep("SentOTP");
            if (TempData["SentOTP"].ToString() == otp)
            {
                return Json(new { success = true, responseText = "OTP Verified." });
             
            }
            else
            {
                return Json(new { success = false, responseText = "OTP Failed." });
            }
        }
    }
}
