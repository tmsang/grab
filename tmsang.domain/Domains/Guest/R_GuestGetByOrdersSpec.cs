using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_GuestGetByOrdersSpec : SpecificationBase<R_Guest>
    {
        readonly IEnumerable<R_Order> orders;

        public R_GuestGetByOrdersSpec(IEnumerable<R_Order> orders)
        {
            this.orders = orders;
        }

        public override Expression<Func<R_Guest, bool>> SpecExpression {
            get {
                return p => 
                    this.orders != null
                    && this.orders.Count() > 0
                    && this.orders.Any(order => order.GuestId == p.Id);
            }
        }
    }
}
