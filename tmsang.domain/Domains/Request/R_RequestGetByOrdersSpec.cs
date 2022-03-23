using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_RequestGetByOrdersSpec : SpecificationBase<R_Request>
    {
        readonly IEnumerable<R_Order> orders;

        public R_RequestGetByOrdersSpec(IEnumerable<R_Order> orders)
        {
            this.orders = orders;
        }

        public override Expression<Func<R_Request, bool>> SpecExpression {
            get {
                return request => this.orders != null
                    && this.orders.Count() > 0
                    && this.orders.Select(p => p.Id).Contains(request.Id);
            }
        }
    }
}
