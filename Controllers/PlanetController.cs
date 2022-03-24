using System;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace App.Controllers
{
    public class PlanetController : Controller
    {
        private readonly ILogger<PlanetController> _logger;
        private readonly PlanetService _planetService;

        public PlanetController(ILogger<PlanetController> logger, PlanetService planetService)
        {
            _logger = logger;
            _planetService = planetService;
        }

        public IActionResult Index()
        {
            var planets = _planetService.ToList();

            return View(planets);
        }
        public IActionResult Mercury()
        {
            var planet = _planetService.Where(p => p.Name == "Mercury").FirstOrDefault();
            if (planet == null)
            {
                return Content("Can not find planet Mercury");
            }

            return View("Detail", planet);
        }

        public IActionResult Venus()
        {
            var planet = _planetService.Where(p => p.Name == "Venus").FirstOrDefault();
            if (planet == null)
            {
                return Content("Can not find planet Venus");
            }

            return View("Detail", planet);
        }

        public IActionResult Mars()
        {
            var planet = _planetService.Where(p => p.Name == "Mars").FirstOrDefault();
            if (planet == null)
            {
                return Content("Can not find planet Mars");
            }

            return View("Detail", planet);
        }

        public IActionResult Earth()
        {
            var planet = _planetService.Where(p => p.Name == "Earth").FirstOrDefault();
            if (planet == null)
            {
                return Content("Can not find planet Earth");
            }

            return View("Detail", planet);
        }
    }
}