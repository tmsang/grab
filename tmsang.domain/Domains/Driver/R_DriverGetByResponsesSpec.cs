using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_DriverGetByResponsesSpec : SpecificationBase<R_Driver>
    {
        readonly IEnumerable<R_Response> responses;

        public R_DriverGetByResponsesSpec(IEnumerable<R_Response> responses)
        {
            this.responses = responses;
        }

        public override Expression<Func<R_Driver, bool>> SpecExpression {
            get {                
                return p => this.responses != null 
                    && this.responses.Count() > 0 
                    && this.responses.Any(i => i.DriverId == p.Id);
            }
        }
    }
}
