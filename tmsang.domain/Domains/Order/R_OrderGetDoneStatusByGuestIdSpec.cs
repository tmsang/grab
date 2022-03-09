using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_OrderGetDoneStatusByGuestIdSpec : SpecificationBase<R_Order>
    {
        readonly Guid accountId;        

        public R_OrderGetDoneStatusByGuestIdSpec(Guid accountId)
        {
            this.accountId = accountId;            
        }

        public override Expression<Func<R_Order, bool>> SpecExpression {
            get {
                return p => p.GuestId == accountId 
                    && (p.Status == E_OrderStatus.Ended || p.Status == E_OrderStatus.Evaluation);
            }
        }
    }
}
