using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_OrderGetByRequestsSpec : SpecificationBase<R_Order>
    {
        readonly IEnumerable<R_Request> requests;

        public R_OrderGetByRequestsSpec(IEnumerable<R_Request> requests)
        {
            this.requests = requests;
        }

        public override Expression<Func<R_Order, bool>> SpecExpression {
            get {
                return p => 
                    this.requests != null
                    && this.requests.Count() > 0
                    && this.requests.Any(request => request.Id == p.Id);
            }
        }
    }
}
