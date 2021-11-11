using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_LocationGetSpec: SpecificationBase<R_Location>
    {
        readonly string Address;

        public R_LocationGetSpec(string address)
        {
            this.Address = address;
        }

        public override Expression<Func<R_Location, bool>> SpecExpression
        {
            get {
                return p => p.Address == this.Address;
            }
        }
    }
}
