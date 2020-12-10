using Hackaton_test.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class MapController : Controller
    {
        IGeolocationService geoService = new GeolocationService();
        public IActionResult Index()
        {
            
            ViewBag.Locations = geoService.GetGeolocations();
            
            ViewData["UserNickname"] = HttpContext.Session.GetString("UserNickname");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["UserSurname"] = HttpContext.Session.GetString("UserSurname");

            return View();
        }
    }
}