using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_GuestGetByStatusSpec : SpecificationBase<R_Guest>
    {
        readonly E_Status status;

        public R_GuestGetByStatusSpec(E_Status status)
        {
            this.status = status;
        }

        public override Expression<Func<R_Guest, bool>> SpecExpression
        {
            get {
                return p => p.AccountStatus == this.status;
            }
        }
    }
}
