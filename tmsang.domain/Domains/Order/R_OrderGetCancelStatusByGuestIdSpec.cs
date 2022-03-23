using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_OrderGetCancelStatusByGuestIdSpec : SpecificationBase<R_Order>
    {
        readonly Guid accountId;        

        public R_OrderGetCancelStatusByGuestIdSpec(Guid accountId)
        {
            this.accountId = accountId;            
        }

        public override Expression<Func<R_Order, bool>> SpecExpression {
            get {
                return p => p.GuestId == accountId 
                    && (p.Status == E_OrderStatus.CancelByUser || 
                        p.Status == E_OrderStatus.CancelByDriver ||
                        p.Status == E_OrderStatus.CancelByAdmin ||
                        p.Status == E_OrderStatus.CancelBySystem);
            }
        }
    }
}
