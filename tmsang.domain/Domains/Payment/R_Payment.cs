using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    // Request -> RequestId (set Id in to Root -> prone to update)
    public class R_Payment: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }                

        public virtual E_PaymentType Type { get; protected set; }
        public virtual string CardNumber { get; protected set; }
        public virtual bool Paid { get; protected set; }

        // relationship child (1-1)
        public virtual Guid RequestId { get; protected set; }

        // relationship (1-n)
        public virtual IList<B_PaymentHistory> Histories { get; protected set; }
    }
}
