using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    // Request -> RequestId (set Id in to Root -> prone to update)
    public class R_Response: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }                

        public virtual DateTime Start { get; protected set; }
        public virtual DateTime End { get; protected set; }

        public virtual double Fee { get; protected set; }         // tien to A_ mang y nghia la cot tinh toan -> nguyen tac: khong dua cot tinh toan de luu tru
        public virtual double Tax { get; protected set; }         // tien to A_ mang y nghia la cot tinh toan -> nguyen tac: khong dua cot tinh toan vao luu tru

        // relationship child (1-1)
        public virtual Guid RequestId { get; protected set; }

        // relationship child (1-n: n)
        public virtual Guid DriverId { get; protected set; }
        public virtual R_Driver Driver { get; protected set; }

        // relationship (1-n: 1)
        public virtual IList<B_ResponseHistory> Histories { get; protected set; }
    }
}
