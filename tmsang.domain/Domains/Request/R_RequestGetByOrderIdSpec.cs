using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_RequestGetByOrderIdSpec : SpecificationBase<R_Request>
    {
        readonly IEnumerable<R_Order> orders;

        public R_RequestGetByOrderIdSpec(IEnumerable<R_Order> orders)
        {
            this.orders = orders;
        }

        public override Expression<Func<R_Request, bool>> SpecExpression {
            get {
                return k => this.orders.Any(h => h.Id == k.Id);
            }
        }
    }
}
