using System;

namespace tmsang.domain
{
    public class B_DriverFeePolicy: BaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual Guid AccountId { get; protected set; }
        public virtual int FeePolicyId { get; protected set; }
        public virtual DateTime From { get; protected set; }
        public virtual DateTime To { get; protected set; }
        public virtual E_Status Status { get; protected set; }
    }
}
