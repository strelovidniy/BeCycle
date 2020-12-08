using Hackaton_test.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_test.Controllers
{
    public class GeolocationController:Controller
    {
        GeolocationService geoService = new GeolocationService();
        public IActionResult Index()
        {
            ViewBag.Locations = geoService.geolocationList;
            return View();
        }
    }
}