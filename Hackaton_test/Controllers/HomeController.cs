using System.Collections.Generic;
using Hackaton_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hackaton_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) => _logger = logger;
        
        //TODO: add pull out from database

        public IActionResult Index(SportType sportType)
        {
            //pull out all posters that have the same sporttype
            var posters = new List<Poster>()
            {
                new Poster() {PosterId = 1,Title = "first",Description = "smth1",SportType = SportType.Extreme}, 
                new Poster() {PosterId = 2,Title = "second",Description = "smth2", SportType = SportType.Extreme},
                new Poster() {PosterId = 3, Title = "third",Description = "smth3",SportType = SportType.Extreme},
            };
            return View(posters);
        }


        public IActionResult Privacy() => View();
    }
}
