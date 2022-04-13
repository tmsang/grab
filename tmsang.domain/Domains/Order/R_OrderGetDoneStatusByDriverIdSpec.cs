using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_OrderGetDoneStatusByDriverIdSpec : SpecificationBase<R_Response>
    {
        readonly IEnumerable<R_Order> orders;
        readonly Guid driverId;        

        public R_OrderGetDoneStatusByDriverIdSpec(IEnumerable<R_Order> orders, Guid driverId)
        {
            this.orders = orders;
            this.driverId = driverId;            
        }

        public override Expression<Func<R_Response, bool>> SpecExpression {
            get {
                return response => response.DriverId == driverId
                    && this.orders
                        .Where(p => p.Status == E_OrderStatus.Ended || p.Status == E_OrderStatus.Evaluation)
                        .Select(p => p.Id)
                        .Contains(response.Id);                                
            }
        }
    }
}
