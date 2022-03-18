using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_ResponseGetAllSpec : SpecificationBase<R_Response>
    {        

        public R_ResponseGetAllSpec()
        {            
        }

        public override Expression<Func<R_Response, bool>> SpecExpression {
            get {
                return p => 1 == 1;
            }
        }
    }
}
