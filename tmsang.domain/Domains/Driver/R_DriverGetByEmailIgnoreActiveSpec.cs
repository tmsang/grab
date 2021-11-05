using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_DriverGetByEmailIgnoreActiveSpec : SpecificationBase<R_Driver>
    {
        readonly string email;

        public R_DriverGetByEmailIgnoreActiveSpec(string email)
        {
            this.email = email;
        }

        public override Expression<Func<R_Driver, bool>> SpecExpression
        {
            get
            {
                return p => p.Email == this.email;
            }
        }
    }
}
