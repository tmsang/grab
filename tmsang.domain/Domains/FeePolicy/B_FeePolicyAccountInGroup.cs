using System;

namespace tmsang.domain
{
    public class B_FeePolicyAccountInGroup: BaseEntity
    {
        public virtual int Id { get; protected set; }
        
        public virtual Guid GroupId { get; protected set; }
        public virtual Guid AccountId { get; protected set; }
    }
}
