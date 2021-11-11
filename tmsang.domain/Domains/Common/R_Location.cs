using System;

namespace tmsang.domain
{
    public class R_Location: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Address { get; protected set; }
        public virtual string Latitude { get; protected set; }
        public virtual string Longtitude { get; protected set; }


        public static R_Location Create(string address, string latitude, string longtitude) {
            return Create(Guid.NewGuid(), address, latitude, longtitude);
        }

        public static R_Location Create(Guid id, string address, string latitude, string longtitude) {
            var location = new R_Location { 
                Id = id,
                Address = address,
                Latitude = latitude,
                Longtitude = longtitude
            };

            // raise event ???

            return location;
        }
    }
}
