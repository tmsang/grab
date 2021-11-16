using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class R_FeePolicyGetCostSpec : SpecificationBase<R_FeePolicy>
    {
        readonly string provinceOrCity;
        readonly Guid groupId;

        public R_FeePolicyGetCostSpec(string provinceOrCity, Guid groupId)
        {
            this.provinceOrCity = provinceOrCity;
            this.groupId = groupId;
        }

        public override Expression<Func<R_FeePolicy, bool>> SpecExpression { 
            get
            {
                return p => p.ProvinceOrCity == this.provinceOrCity && p.GroupId == this.groupId;
            }
        }
    }
}
