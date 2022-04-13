using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_DriverGetByStatusSpec : SpecificationBase<R_Driver>
    {
        readonly E_Status status;

        public R_DriverGetByStatusSpec(E_Status status)
        {
            this.status = status;
        }

        public override Expression<Func<R_Driver, bool>> SpecExpression
        {
            get {
                return p => p.AccountStatus == status;
            }
        }
    }
}
