using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    // Request -> RequestId (set Id in to Root -> prone to update)
    public class R_Evaluation: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }        
        public virtual int Rating { get; protected set; }
        public virtual string Note { get; protected set; }

        // relationship child (1-1)
        public virtual Guid RequestId { get; protected set; }

        // relationship (1-n)
        public virtual IList<B_EvaluationHistory> Histories { get; protected set; }
    }
}
