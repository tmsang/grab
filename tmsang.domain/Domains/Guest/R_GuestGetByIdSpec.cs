using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_GuestGetByIdSpec : SpecificationBase<R_Guest>
    {
        readonly Guid id;

        public R_GuestGetByIdSpec(Guid id)
        {
            this.id = id;
        }

        public override Expression<Func<R_Guest, bool>> SpecExpression
        {
            get {
                return p => p.AccountStatus == E_Status.Actived
                            && p.Id == this.id;
            }
        }
    }
}
