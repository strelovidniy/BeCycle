using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Hackaton_test.Services
{
    public class GeolocationService
    {
        public  List<string> geolocationList = new List<string>()
        {
            "49.820086,24.024571",
            "49.826936,24.023883",
            "49.829526,24.015136",
            "49.826688,24.009532",
            "49.847279,24.068100"
        };
        
        public (double? latitude, double? longitude) GetGeolocation()
        {
            //  This example duplicates the following CURL request:
            //  curl -d @your_filename.json -H "Content-Type: application/json" -i "https://www.googleapis.com/geolocation/v1/geolocate?key=AIzaSyCKWhiZ4XLxhv6EhVHCUr333c912hrVCuI"

            //  This example requires the Chilkat API to have been previously unlocked.
            //  See Global Unlock Sample for sample code.

            var rest = new Chilkat.Rest();
            
            //  Connect to the Google API REST server.
            var bTls = true;
            var port = 443;
            var bAutoReconnect = true;
            var success = rest.Connect("www.googleapis.com", port, bTls, bAutoReconnect);

            //  Add the Content-Type request header.
            rest.AddHeader("Content-Type", "application/json");

            //  Add your API key as a query parameter
            rest.AddQueryParam("key", "AIzaSyCKWhiZ4XLxhv6EhVHCUr333c912hrVCuI");

            //  The JSON query is contained in the body of the HTTP POST.
            //  This is a sample query (which we'll dynamically build in this example)
            //  {
            //   "homeMobileCountryCode": 310,
            //   "homeMobileNetworkCode": 260,
            //   "radioType": "gsm",
            //   "carrier": "T-Mobile",
            //   "cellTowers": [
            //    {
            //    "cellId": 39627456,
            //     "locationAreaCode": 40495,
            //     "mobileCountryCode": 310,
            //     "mobileNetworkCode": 260,
            //     "age": 0,
            //     "signalStrength": -95
            //    }
            //   ],
            //   "wifiAccessPoints": [
            //    {
            //     "macAddress": "01:23:45:67:89:AB",
            //     "signalStrength": 8,
            //     "age": 0,
            //     "signalToNoiseRatio": -65,
            //     "channel": 8
            //    },
            //    {
            //     "macAddress": "01:23:45:67:89:AC",
            //     "signalStrength": 4,
            //     "age": 0
            //    }
            //   ]
            //  }

            var json = new Chilkat.JsonObject();

            json.AppendInt("homeMobileCountryCode", 310);
            json.AppendInt("homeMobileNetworkCode", 260);
            json.AppendString("radioType", "gsm");
            json.AppendString("carrier", "T-Mobile");

            var aCellTowers = json.AppendArray("cellTowers");

            aCellTowers.AddObjectAt(0);

            var oCellTower = aCellTowers.ObjectAt(0);

            oCellTower.AppendInt("cellId", 39627456);
            oCellTower.AppendInt("locationAreaCode", 40495);
            oCellTower.AppendInt("mobileCountryCode", 310);
            oCellTower.AppendInt("mobileNetworkCode", 260);
            oCellTower.AppendInt("age", 0);
            oCellTower.AppendInt("signalStrength", -95);

            var aWifi = json.AppendArray("wifiAccessPoints");
            aWifi.AddObjectAt(0);
            var oPoint = aWifi.ObjectAt(0);
            oPoint.AppendString("macAddress", "01:23:45:67:89:AB");
            oPoint.AppendInt("signalStrength", 8);
            oPoint.AppendInt("age", 0);
            oPoint.AppendInt("signalToNoiseRatio", -65);
            oPoint.AppendInt("channel", 8);

            aWifi.AddObjectAt(1);

            oPoint = aWifi.ObjectAt(1);

            oPoint.AppendString("macAddress", "01:23:45:67:89:AC");
            oPoint.AppendInt("signalStrength", 4);
            oPoint.AppendInt("age", 0);

            var responseJson = rest.FullRequestString("POST", "/geolocation/v1/geolocate", json.Emit());
            if (rest.LastMethodSuccess != true)
            {
                Console.WriteLine(rest.LastErrorText);
                return (null, null);
            }

            //  When successful, the response code is 200.
            if (rest.ResponseStatusCode != 200)
            {
                //  Examine the request/response to see what happened.
                Console.WriteLine("response status code = " + Convert.ToString(rest.ResponseStatusCode));
                Console.WriteLine("response status text = " + rest.ResponseStatusText);
                Console.WriteLine("response header: " + rest.ResponseHeader);
                Console.WriteLine("response JSON: " + responseJson);
                Console.WriteLine("---");
                Console.WriteLine("LastRequestStartLine: " + rest.LastRequestStartLine);
                Console.WriteLine("LastRequestHeader: " + rest.LastRequestHeader);
                return (null, null);
            }

            json.EmitCompact = false;
            Console.WriteLine("JSON request body: " + json.Emit());

            //  The JSON response should look like this:
            //  {
            //   "location": {
            //   "lat": 37.4248297,
            //    "lng": -122.07346549999998
            //   },
            //   "accuracy": 1145.0
            //  }

            Console.WriteLine("JSON response: " + responseJson);

            var jsonResp = new Chilkat.JsonObject();
            jsonResp.Load(responseJson);

            var jsonLoc = jsonResp.ObjectOf("location");
            //  Any JSON value can be obtained as a string..
            var latitude = jsonLoc.StringOf("lat");
            Console.WriteLine("latitude = " + latitude);
            var longitude = jsonLoc.StringOf("lng");
            Console.WriteLine("longitude = " + longitude);

            return (double.Parse(latitude), double.Parse(longitude));
        }
    }
}
