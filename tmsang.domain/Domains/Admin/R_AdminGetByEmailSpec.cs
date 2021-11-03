using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_AdminGetByEmailSpec : SpecificationBase<R_Admin>
    {
        readonly string email;

        public R_AdminGetByEmailSpec(string email)
        {
            this.email = email;
        }

        public override Expression<Func<R_Admin, bool>> SpecExpression
        {
            get {
                return p => p.Mode == E_Mode.Active
                            && p.Email == this.email;
            }
        }
    }
}
