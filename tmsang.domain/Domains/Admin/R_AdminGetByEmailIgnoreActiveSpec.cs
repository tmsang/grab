using System;
using System.Linq.Expressions;

namespace tmsang.domain
{    
    public class R_AdminGetByEmailIgnoreActiveSpec : SpecificationBase<R_Admin>
    {
        readonly string email;

        public R_AdminGetByEmailIgnoreActiveSpec(string email)
        {
            this.email = email;
        }

        public override Expression<Func<R_Admin, bool>> SpecExpression
        {
            get
            {
                return p => p.Email == this.email;
            }
        }
    }
}
