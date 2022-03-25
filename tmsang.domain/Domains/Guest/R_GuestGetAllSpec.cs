using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_GuestGetAllSpec : SpecificationBase<R_Guest>
    {        
        public R_GuestGetAllSpec()
        {            
        }

        public override Expression<Func<R_Guest, bool>> SpecExpression
        {
            get {
                return p => 1 == 1;
            }
        }
    }
}
