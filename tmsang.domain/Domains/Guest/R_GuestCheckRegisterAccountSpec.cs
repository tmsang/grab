using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_GuestCheckRegisterAccountSpec : SpecificationBase<R_Guest>
    {
        readonly string email;
        readonly string phone;

        public R_GuestCheckRegisterAccountSpec(string email, string phone)
        {
            this.email = email;
            this.phone = phone;
        }

        public override Expression<Func<R_Guest, bool>> SpecExpression
        {
            get
            {
                return p => p.AccountStatus == E_Status.Active
                            && (p.Email == this.email || p.Phone == this.phone);
            }
        }
    }
}
