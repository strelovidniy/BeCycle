using System.Collections.Generic;

namespace Hackaton_test.Services
{
    public interface IGeolocationService
    {
        void SetGeolocation(string geolocation);
        List<string> GetGeolocations();
        void RemoveGeolocation(string geolocation);
    }
}