using System;

namespace tmsang.domain
{
    public class B_DriverLocation : BaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual double Lat { get; protected set; }
        public virtual double Lng { get; protected set; }        
        public virtual long Date { get; protected set; }

        // relationship child
        public virtual Guid AccountId { get; protected set; }
        public virtual R_Driver Driver { get; protected set; }

        public static B_DriverLocation Create(double lat, double lng, long date)
        {
            var location = new B_DriverLocation
            {
                Lat = lat,
                Lng = lng,
                Date = date
            };

            return location;
        }

        public static B_DriverLocation CreateForSeed(double lat, double lng, long date, Guid accountId, int id)
        {
            var location = Create(lat, lng, date);
            location.AccountId = accountId;
            location.Id = id;

            return location;
        }
    }
}
