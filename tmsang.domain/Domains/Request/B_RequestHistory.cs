using System;

namespace tmsang.domain
{
    public class B_RequestHistory: BaseEntity
    {
        public virtual long Id { get; protected set; }        
        public virtual E_OrderStatus OrderStatusId { get; protected set; }        
        public virtual DateTime HappenDate { get; protected set; }
        public virtual string Description { get; protected set; }

        // relationship (1-n: n)
        public virtual Guid RequestId { get; protected set; }           // == orderId
        public virtual R_Request Request { get; protected set; }

        public static B_RequestHistory Create(
            Guid orderId, E_OrderStatus orderStatusId, DateTime happenDate, string description
        ) 
        {
            return new B_RequestHistory {
                RequestId = orderId,
                OrderStatusId = orderStatusId,
                HappenDate = happenDate,
                Description = description
            };
        }
    }
}
