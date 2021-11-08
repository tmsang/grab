using System;

namespace tmsang.domain
{
    public class R_FeePolicy: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
                                
        public virtual R_FeePolicyGroup Group { get; protected set; }
        public virtual M_PersonalPolicyType PersonalPolicyType { get; protected set; }
        public virtual R_Location Location { get; protected set; }
    }
}
