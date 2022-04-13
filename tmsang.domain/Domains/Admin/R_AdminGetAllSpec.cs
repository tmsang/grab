using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_AdminGetAllSpec : SpecificationBase<R_Admin>
    {        
        public R_AdminGetAllSpec()
        {            
        }

        public override Expression<Func<R_Admin, bool>> SpecExpression
        {
            get {
                return p => 1 == 1;
            }
        }
    }
}
