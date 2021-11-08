using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_DriverCheckRegisterAccountSpec : SpecificationBase<R_Driver>
    {
        readonly string email;
        readonly string phone;

        public R_DriverCheckRegisterAccountSpec(string email, string phone)
        {
            this.email = email;
            this.phone = phone;
        }

        public override Expression<Func<R_Driver, bool>> SpecExpression
        {
            get
            {
                return p => p.AccountStatus == E_Status.Active
                            && (p.Email == this.email || p.Phone == this.phone);
            }
        }
    }
}
