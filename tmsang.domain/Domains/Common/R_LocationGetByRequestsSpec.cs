using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_LocationGetByRequestsSpec : SpecificationBase<R_Location>
    {
        readonly IEnumerable<R_Request> requests;

        public R_LocationGetByRequestsSpec(IEnumerable<R_Request> requests)
        {
            this.requests = requests;
        }

        public override Expression<Func<R_Location, bool>> SpecExpression {
            get {
                return k => this.requests != null 
                    && this.requests.Count() > 0
                    && this.requests.Any(i => i.FromLocationId == k.Id || i.ToLocationId == k.Id);
            }
        }
    }
}
