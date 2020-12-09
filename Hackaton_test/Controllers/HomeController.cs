using System.Collections.Generic;
using System.Linq;
using Hackaton_test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) => _logger = logger;
        
        [AllowAnonymous]
        public IActionResult Index(SportType sportType = 0)
        {
            List<Poster> list;
            using (var db = new ApplicationContext())
            {
               list = db.Posters.Where(poster => poster.SportType == sportType).ToList();
            }

            return View(list);
        }
    }
}
