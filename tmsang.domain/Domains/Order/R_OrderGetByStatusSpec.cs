using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_OrderGetByStatusSpec : SpecificationBase<R_Order>
    {
        readonly E_OrderStatus orderStatus;

        public R_OrderGetByStatusSpec(E_OrderStatus orderStatus)
        {
            this.orderStatus = orderStatus;
        }

        public override Expression<Func<R_Order, bool>> SpecExpression {
            get {
                return p => p.Status == orderStatus;
            }
        }
    }
}
