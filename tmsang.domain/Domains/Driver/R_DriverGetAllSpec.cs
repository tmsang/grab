using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_DriverGetAllSpec : SpecificationBase<R_Driver>
    {        
        public R_DriverGetAllSpec()
        {            
        }

        public override Expression<Func<R_Driver, bool>> SpecExpression
        {
            get {
                return p => 1 == 1;
            }
        }
    }
}
