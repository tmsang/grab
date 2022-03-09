using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_RequestGetByResponsesSpec : SpecificationBase<R_Request>
    {
        readonly IEnumerable<R_Response> responses;

        public R_RequestGetByResponsesSpec(IEnumerable<R_Response> responses)
        {
            this.responses = responses;
        }

        public override Expression<Func<R_Request, bool>> SpecExpression {
            get {
                return request => this.responses != null
                    && this.responses.Count() > 0
                    && this.responses.Any(h => h.Id == request.Id);
            }
        }
    }
}
