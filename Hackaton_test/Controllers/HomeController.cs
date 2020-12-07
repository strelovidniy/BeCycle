using Hackaton_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hackaton_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
