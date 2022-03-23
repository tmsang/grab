using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_OrderGetDoneStatusByGuestIdSpec : SpecificationBase<R_Order>
    {
        readonly Guid guestId;        

        public R_OrderGetDoneStatusByGuestIdSpec(Guid guestId)
        {
            this.guestId = guestId;            
        }

        public override Expression<Func<R_Order, bool>> SpecExpression {
            get {
                return p => p.GuestId == guestId 
                    && (p.Status == E_OrderStatus.Ended || p.Status == E_OrderStatus.Evaluation);
            }
        }
    }
}
