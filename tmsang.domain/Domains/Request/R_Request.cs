using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    // Request -> RequestId (set Id in to Root -> prone to update)
    public class R_Request: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }        

        public virtual R_Location From { get; protected set; }
        public virtual R_Location To { get; protected set; }

        public virtual double Distance { get; protected set; }
        public virtual double Cost { get; protected set; }

        public virtual DateTime RequestDateTime { get; protected set; }
        public virtual string Reason { get; protected set; }

        // relationship (1-n: n)        
        public virtual Guid GuestId { get; protected set; }
        public virtual R_Guest Guest { get; protected set; }

        // relationship (1-n: 1)
        public virtual IList<B_RequestHistory> Histories { get; protected set; }
    }
}
