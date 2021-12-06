using System.Collections.Generic;

namespace Hackaton_test.Services
{
    public class GeolocationService : IGeolocationService
    {
        private List<string> geolocations = new List<string>
        {   "49.848540,24.040773",
            "49.844123,24.055628",
            "49.852610,23.994028",
            "49.813343,24.154294",
            "49.797176,23.901201",
            "49.812737,23.893313"
        };

        public List<string> GetGeolocations()
        {
            return geolocations;
        }

        public void SetGeolocation(string geolocation)
        {
            geolocations.Add(geolocation);
        }

        public void RemoveGeolocation(string geolocation)
        {
            geolocations.Remove(geolocation);
        }
    }
}