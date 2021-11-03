using System;

namespace tmsang.domain
{
    public class R_Payment: BaseEntity
    {
        public virtual int Id { get; protected set; }
        
        public virtual Guid OrderId { get; protected set; }

        public virtual E_PaymentType Type { get; protected set; }
        public virtual string CardNumber { get; protected set; }
        public virtual bool Paid { get; protected set; }

    }
}
