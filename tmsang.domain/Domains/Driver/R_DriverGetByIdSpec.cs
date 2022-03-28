using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_DriverGetByIdSpec : SpecificationBase<R_Driver>
    {
        readonly Guid id;

        public R_DriverGetByIdSpec(Guid id)
        {
            this.id = id;
        }

        public override Expression<Func<R_Driver, bool>> SpecExpression
        {
            get {
                return p => p.AccountStatus == E_Status.Actived 
                            && p.Id == this.id;
            }
        }
    }
}
