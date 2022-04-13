using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_DriverGetByNotInIdsSpec : SpecificationBase<R_Driver>
    {
        readonly List<Guid> ids;

        public R_DriverGetByNotInIdsSpec(List<Guid> ids)
        {
            this.ids = ids;
        }

        public override Expression<Func<R_Driver, bool>> SpecExpression
        {
            get {
                return p => p.AccountStatus == E_Status.Actived 
                            && this.ids != null                            
                            && this.ids.All(i => i != p.Id);
            }
        }
    }
}
