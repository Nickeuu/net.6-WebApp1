﻿using Microsoft.AspNetCore.Mvc;

namespace net._6_WebApp1.Controllers
{
    public class RaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}