using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Hackaton_test.Models.GoogleMaps;


namespace Hackaton_test.Controllers
{
    public class MapController : Controller
    {
        // GET
        

        public JsonResult GetData() 
        {
            List<DestinationPoint> Destinations = new List<DestinationPoint>();
            Destinations.Add(new DestinationPoint() {DestinationPointId = 1, PlaceName = "Підгорецький замок",
                GeoLat = 49.943126779033044, GeoLong = 24.983551168831774, Traffic = 1.0});
            return Json(Destinations, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}