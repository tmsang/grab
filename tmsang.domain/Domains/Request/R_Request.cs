using System;

namespace tmsang.domain
{
    public class R_Request: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }

        public virtual Guid OrderId { get; protected set; }

        public virtual R_Location From { get; protected set; }
        public virtual R_Location To { get; protected set; }

        public virtual double Distance { get; protected set; }
        public virtual double Cost { get; protected set; }

        public virtual DateTime RequestDateTime { get; protected set; }
        public virtual string Reason { get; protected set; }                                
    }
}
