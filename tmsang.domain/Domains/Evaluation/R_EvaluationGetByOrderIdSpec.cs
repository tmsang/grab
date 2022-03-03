using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_EvaluationGetByOrderIdSpec : SpecificationBase<R_Evaluation>
    {
        readonly IEnumerable<R_Order> orders;

        public R_EvaluationGetByOrderIdSpec(IEnumerable<R_Order> orders)
        {
            this.orders = orders;
        }

        public override Expression<Func<R_Evaluation, bool>> SpecExpression {
            get {
                return k => this.orders != null
                    && this.orders.Count() > 0
                    && this.orders.Any(h => h.Id == k.Id);
            }
        }
    }
}
