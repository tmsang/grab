﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace tmsang.domain
{
    public class R_OrderGetDoneStatusByDriverIdSpec : SpecificationBase<R_Response>
    {
        readonly IEnumerable<R_Order> orders;
        readonly Guid accountId;        

        public R_OrderGetDoneStatusByDriverIdSpec(IEnumerable<R_Order> orders, Guid accountId)
        {
            this.orders = orders;
            this.accountId = accountId;            
        }

        public override Expression<Func<R_Response, bool>> SpecExpression {
            get {
                return response => response.DriverId == accountId && 
                    orders.Where(i => i.Id == response.Id 
                                    && (i.Status == E_OrderStatus.Ended || i.Status == E_OrderStatus.Evaluation)
                                ).Any();
            }
        }
    }
}
