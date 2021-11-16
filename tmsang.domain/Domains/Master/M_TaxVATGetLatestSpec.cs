using System;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public class M_TaxVATGetLatestSpec : SpecificationBase<M_TaxVAT>
    {
        public M_TaxVATGetLatestSpec()
        {

        }

        public override Expression<Func<M_TaxVAT, bool>> SpecExpression {
            get {
                return p => p.Status == E_Status.Active &&
                    p.From <= DateTime.Now && p.To >= DateTime.Now;
            }
        }
    }
}
