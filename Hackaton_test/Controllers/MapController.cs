using System;
using System.Linq;
using System.Security.Claims;
using Hackaton_test.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class MapController : Controller
    {
        IGeolocationService geoService = new GeolocationService();
        public IActionResult Index()
        {
            
            ViewBag.Locations = geoService.GetGeolocations();

            var claimsData = ((ClaimsIdentity)HttpContext.User.Identity)?.Claims;

            var claimsDictionary = claimsData?
                .ToDictionary(key => key.Type.Split('/',
                        StringSplitOptions.RemoveEmptyEntries).TakeLast(1).FirstOrDefault(),
                    value => value.Value);

            ViewData["UserEmail"] = claimsDictionary?["emailaddress"];
            ViewData["UserName"] = claimsDictionary?["givenname"];
            ViewData["UserSurname"] = claimsDictionary?["surname"];

            return View();
        }
    }
}