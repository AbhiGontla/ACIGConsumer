using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACIGConsumer.Components.UserPanel
{
    public class UserPanelViewComponent : ViewComponent
    {
        private ICustomerService _customerService;
        public UserPanelViewComponent(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IViewComponentResult Invoke()
        {
            //second request, get value marking it from deletion
            string nationalId = TempData["NationalId"].ToString();

            TempData["YOB"].ToString();
            //later on decide to keep it
            TempData.Keep("YOB");
            TempData.Keep("NationalId");
            ViewBag.customerDetails=_customerService.GetCustomerById(nationalId);
            ViewBag.requestPath = HttpContext.Request.Path.Value;
            return View();
        }
    }
}
