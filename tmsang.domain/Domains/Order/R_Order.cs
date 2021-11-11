using System;
using System.Collections.Generic;
using System.Text;

namespace tmsang.domain
{
    public class R_Order: BaseEntity, IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
    }
}
