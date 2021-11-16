using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_GuestGetByAccountIdsSpec : SpecificationBase<R_Guest>
    {
        readonly IList<Guid> guestIds;

        public R_GuestGetByAccountIdsSpec(IList<Guid> guestIds)
        {
            this.guestIds = guestIds;
        }

        public override Expression<Func<R_Guest, bool>> SpecExpression {
            get {
                return p => this.guestIds.Any(i => i == p.Id);
            }
        }
    }
}
