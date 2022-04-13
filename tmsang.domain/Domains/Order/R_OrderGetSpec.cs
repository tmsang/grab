using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_OrderGetSpec : SpecificationBase<R_Order>
    {
        readonly Guid orderId;

        public R_OrderGetSpec(Guid orderId)
        {
            this.orderId = orderId;
        }

        public override Expression<Func<R_Order, bool>> SpecExpression {
            get {
                return p => p.Id == this.orderId;
            }
        }
    }
}
