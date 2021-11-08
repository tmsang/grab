using System;

namespace tmsang.domain
{
    public class B_EvaluationHistory: BaseEntity
    {
        public virtual long Id { get; protected set; }        
        public virtual int OrderStatusId { get; protected set; }
        public virtual DateTime HappenDate { get; protected set; }
        public virtual string Description { get; protected set; }

        // relationship (1-n: n)
        public virtual Guid EvaluationId { get; protected set; }
        public virtual R_Evaluation Evaluation { get; protected set; }
    }
}
