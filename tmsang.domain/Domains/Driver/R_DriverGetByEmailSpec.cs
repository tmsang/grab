using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_DriverGetByEmailSpec : SpecificationBase<R_Driver>
    {
        readonly string email;

        public R_DriverGetByEmailSpec(string email)
        {
            this.email = email;
        }

        public override Expression<Func<R_Driver, bool>> SpecExpression
        {
            get {
                return p => p.AccountStatus == E_Status.Actived
                            && p.Email == this.email;
            }
        }
    }
}
