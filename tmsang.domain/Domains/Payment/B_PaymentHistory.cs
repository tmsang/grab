using System;

namespace tmsang.domain
{
    public class B_PaymentHistory: BaseEntity
    {
        public virtual long Id { get; protected set; }

        public virtual Guid OrderId { get; protected set; }
        public virtual int OrderStatusId { get; protected set; }

        public virtual DateTime HappenDate { get; protected set; }
        public virtual string Description { get; protected set; }
    }
}
