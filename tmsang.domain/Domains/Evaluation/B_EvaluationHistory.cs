using System;

namespace tmsang.domain
{
    public class B_EvaluationHistory: BaseEntity
    {
        public virtual long Id { get; protected set; }        
        public virtual E_OrderStatus OrderStatusId { get; protected set; }
        public virtual DateTime HappenDate { get; protected set; }
        public virtual string Description { get; protected set; }

        // relationship (1-n: n)
        public virtual Guid EvaluationId { get; protected set; }            // it's orderId
        public virtual R_Evaluation Evaluation { get; protected set; }

        public static B_EvaluationHistory Create(
            Guid orderId, E_OrderStatus orderStatusId, DateTime happenDate, string description
        )
        {
            return new B_EvaluationHistory
            {
                EvaluationId = orderId,
                OrderStatusId = orderStatusId,
                HappenDate = happenDate,
                Description = description
            };
        }
    }
}
