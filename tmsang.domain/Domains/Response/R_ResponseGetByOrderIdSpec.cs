using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_ResponseGetByOrderIdSpec : SpecificationBase<R_Response>
    {
        readonly IEnumerable<R_Order> orders;

        public R_ResponseGetByOrderIdSpec(IEnumerable<R_Order> orders)
        {
            this.orders = orders;
        }

        public override Expression<Func<R_Response, bool>> SpecExpression {
            get {
                return k => this.orders.Any(h => h.Id == k.Id);
            }
        }
    }
}
