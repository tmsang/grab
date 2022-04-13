using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_ResponseGetByIdSpec : SpecificationBase<R_Response>
    {
        readonly Guid orderId;

        public R_ResponseGetByIdSpec(Guid orderId)
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
