using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    public class R_FeePolicyGroup: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; }

        // relationship (1-n: 1)
        public virtual IList<B_FeePolicyAccountInGroup> Users { get; protected set; }
    }
}
