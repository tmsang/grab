using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_RequestGetByDateSpec : SpecificationBase<R_Request>
    {
        readonly DateTime dateTime;

        public R_RequestGetByDateSpec(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public override Expression<Func<R_Request, bool>> SpecExpression {
            get {
                return request => request.RequestDateTime.Date == dateTime.Date;
            }
        }
    }
}
