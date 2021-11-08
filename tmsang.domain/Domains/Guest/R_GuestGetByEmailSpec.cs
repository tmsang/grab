using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_GuestGetByEmailSpec : SpecificationBase<R_Guest>
    {
        readonly string email;

        public R_GuestGetByEmailSpec(string email)
        {
            this.email = email;
        }

        public override Expression<Func<R_Guest, bool>> SpecExpression
        {
            get {
                return p => p.AccountStatus == E_Status.Active 
                            && p.Email == this.email;
            }
        }
    }
}
