using Microsoft.AspNetCore.Mvc;
using net._6_WebApp1.Interfaces;
using net._6_WebApp1.Models;
using net._6_WebApp1.Repository;
using net._6_WebApp1.Services;
using net._6_WebApp1.ViewModels;

namespace net._6_WebApp1.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRespository;
        private readonly IPhotoService _photoService;

        public RaceController(IRaceRepository raceRespository, IPhotoService photoService)
        {
            _raceRespository = raceRespository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRespository.GetAll();
            return View(races);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceRespository.GetByIdAsync(id);
            return View(race);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRaceViewModel raceVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(raceVM.Image);

                var race = new Race
                {
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = raceVM.Address.Street,
                        City = raceVM.Address.City,
                        State = raceVM.Address.State,
                    }
                };
                _raceRespository.Add(race);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(raceVM);
        }
    }
}

