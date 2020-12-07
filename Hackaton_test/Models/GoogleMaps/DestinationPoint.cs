namespace Hackaton_test.Models.GoogleMaps
{
    public class DestinationPoint
    {
        public int DestinationPointId { get; set; }
        public string PlaceName { get; set; }
        public double Traffic { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
    }
}