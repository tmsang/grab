using System;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_FeePolicyGroupGetByUserId : SpecificationBase<R_FeePolicyGroup>
    {
        readonly Guid driverId;

        public R_FeePolicyGroupGetByUserId(Guid driverId)
        {
            this.driverId = driverId;
        }

        public override Expression<Func<R_FeePolicyGroup, bool>> SpecExpression {
            get {
                return p => p.Users.Any(i => i.DriverId == this.driverId);
            }
        }
    }
}
