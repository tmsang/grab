using System;

namespace tmsang.domain
{
    public class R_FeePolicy: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }

        public virtual long LocationId { get; protected set; }
        public virtual int PersonalPolicyTypeId { get; protected set; }
        public virtual int GroupId { get; protected set; }                
    }
}
