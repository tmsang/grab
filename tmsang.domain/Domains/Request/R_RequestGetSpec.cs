using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_RequestGetSpec : SpecificationBase<R_Request>
    {
        readonly Guid orderId;

        public R_RequestGetSpec(Guid orderId)
        {
            this.orderId = orderId;
        }

        public override Expression<Func<R_Request, bool>> SpecExpression {
            get {
                return p => p.Id == this.orderId;
            }
        }
    }
}
