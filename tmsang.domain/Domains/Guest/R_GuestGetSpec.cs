using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_GuestGetSpec : SpecificationBase<R_Guest>
    {        
        public R_GuestGetSpec()
        {            
        }

        public override Expression<Func<R_Guest, bool>> SpecExpression
        {
            get {
                return p => p.AccountStatus == E_Status.Active;
            }
        }
    }
}
