using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_ResponseGetSpec : SpecificationBase<R_Response>
    {
        readonly Guid orderId;

        public R_ResponseGetSpec(Guid orderId)
        {
            this.orderId = orderId;
        }

        public override Expression<Func<R_Response, bool>> SpecExpression {
            get {
                return p => p.Id == this.orderId;
            }
        }
    }
}
