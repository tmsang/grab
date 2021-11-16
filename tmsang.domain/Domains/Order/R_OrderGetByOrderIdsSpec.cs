using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_OrderGetByOrderIdsSpec : SpecificationBase<R_Order>
    {
        readonly IList<Guid> orderIds;

        public R_OrderGetByOrderIdsSpec(IList<Guid> orderIds)
        {
            this.orderIds = orderIds;
        }

        public override Expression<Func<R_Order, bool>> SpecExpression {
            get {
                return p => orderIds.Any(i => i == p.Id);
            }
        }
    }
}
