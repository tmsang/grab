using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_OrderGetByResponsesSpec : SpecificationBase<R_Order>
    {
        readonly IEnumerable<R_Response> responses;

        public R_OrderGetByResponsesSpec(IEnumerable<R_Response> responses)
        {
            this.responses = responses;
        }

        public override Expression<Func<R_Order, bool>> SpecExpression {
            get {
                return p => 
                    this.responses != null
                    && this.responses.Count() > 0
                    && this.responses.Any(response => response.Id == p.Id);
            }
        }
    }
}
