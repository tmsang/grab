using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_RequestGetByOrderIdsSpec : SpecificationBase<R_Request>
    {
        readonly IEnumerable<Guid> orderIds;

        public R_RequestGetByOrderIdsSpec(IEnumerable<Guid> orderIds)
        {
            this.orderIds = orderIds;
        }

        public override Expression<Func<R_Request, bool>> SpecExpression {
            get {
                return request => this.orderIds != null
                    && this.orderIds.Count() > 0
                    && this.orderIds.Any(id => id == request.Id);
            }
        }
    }
}
