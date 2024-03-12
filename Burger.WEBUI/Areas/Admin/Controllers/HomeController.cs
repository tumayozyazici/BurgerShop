﻿using Microsoft.AspNetCore.Mvc;

namespace Burger.WEBUI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area(areaName:"Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
