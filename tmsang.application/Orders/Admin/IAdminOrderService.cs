using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tmsang.application
{
    public interface IAdminOrderService
    {

        IEnumerable<AdminRequestDto> RequestsByDate(DateTime date);
        IntervalAdminResultDto IntervalGets(DateTime from, DateTime to);
    }
}
