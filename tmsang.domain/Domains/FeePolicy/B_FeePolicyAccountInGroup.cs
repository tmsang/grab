using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    public class B_FeePolicyAccountInGroup: BaseEntity
    {
        public virtual int Id { get; protected set; }
        
        // relatioship (1-n: n)
        public virtual Guid GroupId { get; protected set; }
        public virtual R_FeePolicyGroup Group { get; protected set; }

        // relationship (1-n: 1)
        public virtual IList<R_Driver> Drivers { get; protected set; }        
    }
}
