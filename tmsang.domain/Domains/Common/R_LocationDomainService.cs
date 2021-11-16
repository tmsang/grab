using BingMapsRESTToolkit;

namespace tmsang.domain
{
    public class R_LocationDomainService
    {
        readonly IRepository<R_Location> locationRepository;

        public R_LocationDomainService(IRepository<R_Location> locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public R_Location AddIfNotExists(string address, string latitude, string longtitude) {
            // check if exists
            var location = this.locationRepository.FindOne(new R_LocationGetSpec(address));
            if (location != null)
            {
                return location;
            }

            // if not exists -> create
            location = R_Location.Create(address, latitude, longtitude);
            this.locationRepository.Add(location);

            return location;
        }

        public R_Location AddIfNotExists(string address) {
            // check if exists
            var location = this.locationRepository.FindOne(new R_LocationGetSpec(address));
            if (location != null)
            {
                return location;
            }

            // if not exists -> create
            return AnalyzeAddress(address);
        }

        private R_Location AnalyzeAddress(string address)
        {
            /*
            string url = "https://maps.googleapis.com/maps/api/geocode/xml?address="
                + address
                + "&key=" + Singleton.Instance.GoogleApiKey;
            
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);

                    if (dsResult.Tables[0].Rows[0]["status"].ToString() == "OVER_QUERY_LIMIT") {
                        return R_Location.Create("address test", "213.211", "231", "Ho Chi Minh");
                    }

                    return R_Location.Create(
                        dsResult.Tables["result"].Rows[0]["formatted_address"].ToString(),
                        dsResult.Tables["location"].Rows[0]["lat"].ToString(),
                        dsResult.Tables["location"].Rows[0]["lng"].ToString(),
                        dsResult.Tables["address_component"].Rows[4][0].ToString()
                    );
                }
            }            
            */
            
            var response = Util.GetLocationFromAddress(address);
            var location = (Location)response.ResourceSets[0].Resources[0];

            var result = R_Location.Create(
                    location.Address.FormattedAddress,
                    location.Point.GetCoordinate().Latitude.ToString(),
                    location.Point.GetCoordinate().Longitude.ToString(),
                    location.Address.Locality
                );

            return result;
        }                

    }
}
