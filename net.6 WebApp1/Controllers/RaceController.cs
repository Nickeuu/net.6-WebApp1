using Microsoft.AspNetCore.Mvc;
using net._6_WebApp1.Data;
using net._6_WebApp1.Models;

namespace net._6_WebApp1.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Race> races = _context.Races.ToList();
            return View(races);
        }
    }
}
