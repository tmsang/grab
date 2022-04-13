using System;

namespace tmsang.domain
{
    public class B_ResponseHistory: BaseEntity
    {
        public virtual long Id { get; protected set; }        
        public virtual E_OrderStatus OrderStatusId { get; protected set; }
        public virtual DateTime HappenDate { get; protected set; }
        public virtual string Description { get; protected set; }

        // relationship (1-n: n)
        public virtual Guid ResponseId { get; protected set; }
        public virtual R_Response Response { get; protected set; }

        public static B_ResponseHistory Create(
            Guid responseId, E_OrderStatus status, DateTime happenDate, string description
        ) 
        {
            var history = new B_ResponseHistory { 
                OrderStatusId = status,
                HappenDate = happenDate,
                Description = description,
                ResponseId = responseId
            };

            return history;
        }
    }
}
