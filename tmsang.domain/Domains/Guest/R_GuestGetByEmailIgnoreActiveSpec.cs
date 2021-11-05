using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_GuestGetByEmailIgnoreActiveSpec : SpecificationBase<R_Guest>
    {
        readonly string email;

        public R_GuestGetByEmailIgnoreActiveSpec(string email)
        {
            this.email = email;
        }

        public override Expression<Func<R_Guest, bool>> SpecExpression
        {
            get
            {
                return p => p.Email == this.email;
            }
        }
    }
}
