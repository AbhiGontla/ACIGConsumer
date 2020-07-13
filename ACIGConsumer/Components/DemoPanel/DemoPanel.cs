﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACIGConsumer.Components.DemoPanel
{
    public class DemoPanelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.requestPath = HttpContext.Request.Path.Value;
            return View();
        }
    }
}
