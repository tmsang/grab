using System;

namespace tmsang.domain
{
    public class R_FeePolicyGroup: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; }
    }
}
