using Hackaton_test.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class GeolocationController : Controller
    {
        IGeolocationService geoService = new GeolocationService();
        public IActionResult Index()
        {
            ViewBag.Locations = geoService.GetGeolocations();

            ViewData["UserId"] = HttpContext.Session.GetInt32("UserId");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["UserSurname"] = HttpContext.Session.GetString("UserSurname");

            return View();
        }
    }
}