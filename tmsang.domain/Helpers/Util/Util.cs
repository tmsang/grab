using BingMapsRESTToolkit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace tmsang.domain
{
    public static class Util
    {
        private static HttpClient client = new HttpClient();
        private static string key = "AuZD1lfJajlhr_Cx6GVG9uR4jzS5Y-PF3EWWGrM0SgdGBUh_8D3fvER4D-Xxco2r";

        // =========================================================
        // Extension
        // =========================================================
        public static string ReplaceExtra(this string value, IEnumerable<Tuple<string, string>> toReplace)
        {
            var result = new StringBuilder(value);
            foreach (var item in toReplace)
            {
                result.Replace(item.Item1, item.Item2);
            }
            return result.ToString();
        }


        // =========================================================
        // METHOD
        // =========================================================
        public static Response GetLocationFromAddress(string address)
        {            
            Uri uri = new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Locations?q={0}&key={1}", address, key));
            var streamTask = client.GetStreamAsync(uri);

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
            var response = ser.ReadObject(streamTask.Result) as Response;

            return response;
        }

        public static async Task<(double Distance, double Time)> GetDistanceMatrixAsync(string addressFrom, string addressTo)
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
    }

    
}
