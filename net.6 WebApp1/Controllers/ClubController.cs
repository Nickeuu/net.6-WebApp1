﻿using Microsoft.AspNetCore.Mvc;
using net._6_WebApp1.Data;
using net._6_WebApp1.Models;

namespace net._6_WebApp1.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Club> clubs = _context.Clubs.ToList();
            return View(clubs);
        }
    }
}