using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_ResponseGetByDriverIdSpec : SpecificationBase<R_Response>
    {
        readonly Guid driverId;

        public R_ResponseGetByDriverIdSpec(Guid driverId)
        {
            this.driverId = driverId;
        }

        public override Expression<Func<R_Response, bool>> SpecExpression {
            get {
                return p => p.DriverId == driverId;
            }
        }
    }
}
