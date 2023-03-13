using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net._6_WebApp1.Data;
using net._6_WebApp1.Interfaces;
using net._6_WebApp1.Models;

namespace net._6_WebApp1.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;

        public RaceController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;   
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.GetAll();
            return View(races);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }
    }
}
