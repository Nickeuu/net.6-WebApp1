using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net._6_WebApp1.Data;
using net._6_WebApp1.Interfaces;
using net._6_WebApp1.Models;

namespace net._6_WebApp1.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll();
            return View(clubs);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }
    }
}