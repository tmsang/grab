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
    }
}
