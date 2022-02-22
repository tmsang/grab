using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_DriverGetSpec : SpecificationBase<R_Driver>
    {        
        public R_DriverGetSpec()
        {            
        }

        public override Expression<Func<R_Driver, bool>> SpecExpression
        {
            get {
                return p => p.AccountStatus == E_Status.Active;
            }
        }
    }
}
