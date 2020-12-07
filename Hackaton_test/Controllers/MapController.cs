using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Hackaton_test.Models.GoogleMaps;
using Newtonsoft.Json;


namespace Hackaton_test.Controllers
{
    public class MapController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetData() 
        {
            var Destinations = new List<DestinationPoint>();
            Destinations.Add(new DestinationPoint() 
            {
                DestinationPointId = 1, 
                PlaceName = "Підгорецький замок",
                GeoLat = 49.943126779033044, 
                GeoLong = 24.983551168831774, Traffic = 1.0
            });

            return Json(Destinations, new JsonSerializerSettings());
        }
    }
}