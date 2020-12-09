using System;
using Hackaton_test.Services;
using Microsoft.AspNetCore.Authorization;
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
            return View();
        }
    }
}