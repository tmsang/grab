using System;

namespace tmsang.domain
{
    public class B_DriverTrustLevel: BaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual Guid AccountId { get; protected set; }
        public virtual int Level { get; protected set; }
        public virtual int CancelRequestCounter { get; protected set; }        
    }
}
