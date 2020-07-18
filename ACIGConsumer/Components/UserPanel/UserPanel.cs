using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.RequestHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACIGConsumer.Components.UserPanel
{
    public class UserPanelViewComponent : ViewComponent
    {
        private ICustomerService _customerService;
        private CustomerHandler CustomerHandler;
        public UserPanelViewComponent(ICustomerService customerService,CustomerHandler customerHandler)
        {
            _customerService = customerService;
            CustomerHandler = customerHandler;
        }
        public IViewComponentResult Invoke()
        {
            //second request, get value marking it from deletion
            string nationalId = TempData["NationalId"].ToString();

            TempData["YOB"].ToString();
            //later on decide to keep it
            TempData.Keep("YOB");
            TempData.Keep("NationalId");
            var AllUsers = CustomerHandler.GetAllUsers();
            ViewBag.customerDetails=_customerService.GetCustomerById(nationalId);
            ViewBag.requestPath = HttpContext.Request.Path.Value;
            return View();
        }
    }
}
