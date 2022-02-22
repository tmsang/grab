using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class M_RoutineCostGetCostSpec: SpecificationBase<M_RoutineCost>
    {
        readonly DateTime RequestDate;

        public M_RoutineCostGetCostSpec()
        {
            this.RequestDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public override Expression<Func<M_RoutineCost, bool>> SpecExpression
        {
            get {
                return p => p.Status == E_Status.Active 
                    && p.From <= this.RequestDate 
                    && this.RequestDate <= p.To;
            }
        }
    }
}
