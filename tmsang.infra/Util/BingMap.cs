using BingMapsRESTToolkit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using tmsang.domain;

namespace tmsang.infra
{
    public class BingMap: IBingMap
    {
        private static HttpClient client = new HttpClient();
        private static string key = "AuZD1lfJajlhr_Cx6GVG9uR4jzS5Y-PF3EWWGrM0SgdGBUh_8D3fvER4D-Xxco2r";
        
        // =========================================================
        // METHOD
        // =========================================================
        public Response GetLocationFromAddress(string address)
        {            
            Uri uri = new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Locations?q={0}&key={1}", address, key));
            var streamTask = client.GetStreamAsync(uri);

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
            var response = ser.ReadObject(streamTask.Result) as Response;

            return response;
        }

        public async Task<(double Distance, double Time)> GetDistanceMatrixAsync(string addressFrom, string addressTo)
        {
            /*
            // Post: use Asynchonize (must declare class... for post)
            // public class DistanceMatrixParam
            // {
            //    public IList<DistanceLocation> origins { get; set; }
            //    public IList<DistanceLocation> destinations { get; set; }
            //    public string travelMode { get; set; }
            //    public string startTime { get; set; }        
            // }

            // public class DistanceLocation
            // {
            //    public string latitude { get; set; }
            //    public string longitude { get; set; }
            // }
            // ...

            StringContent content = new StringContent(JsonConvert.SerializeObject(distanceParams), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync("https://localhost:44324/api/Reservation", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                receivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
            }
            */


            DistanceMatrixRequest request = new DistanceMatrixRequest();
            request.Origins = new List<SimpleWaypoint>() {
                new SimpleWaypoint(addressFrom)
            };
            request.Destinations = new List<SimpleWaypoint>() {
                new SimpleWaypoint(addressTo)
            };
            request.TravelMode = TravelModeType.Driving;
            request.StartTime = DateTime.Now;
            request.BingMapsKey = key;

            DistanceMatrix matrix = await request.GetEuclideanDistanceMatrix();
            double distance = matrix.GetDistance(0, 0);
            double timing = matrix.GetTime(0, 0);            

            return (distance, timing);
        }

        public double GetDistanceByCoordinate(double lat1, double lon1, double lat2, double lon2) 
        {
            var R = 6371; // Radius of the earth in km
            var dLat = deg2rad(lat2 - lat1);  // deg2rad below
            var dLon = deg2rad(lon2 - lon1);
            var a =
              Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) *
              Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
              ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;                  // Distance in km

            return d * 1000;                // => convert into m
        }

        private double deg2rad(double deg)
        {
            return deg * (Math.PI / 180);
        }
    }

    
}
