using System;

namespace tmsang.domain
{
    public class B_GuestLocation : BaseEntity
    {                
        public virtual int Id { get; protected set; }
        public virtual double Lat { get; protected set; }
        public virtual double Lng { get; protected set; }        
        public virtual long Date { get; protected set; }

        // relationship child
        public virtual Guid AccountId { get; protected set; }
        public virtual R_Guest Guest { get; protected set; }

        public static B_GuestLocation Create(double lat, double lng, long date) 
        {
            var location = new B_GuestLocation
            {
                Lat = lat,
                Lng = lng,
                Date = date
            };

            return location;
        }
        
        public static B_GuestLocation CreateForSeed(double lat, double lng, long date, Guid accountId, int id)
        {
            var location = Create(lat, lng, date);
            location.AccountId = accountId;
            location.Id = id;

            return location;
        }
    }
}
