using System;
using System.Collections.Generic;

namespace tmsang.application
{
    public interface IAdminOrderService
    {
        void ZaloCall(string zaloUserId);
        IEnumerable<AdminRequestDto> RequestsByDate(DateTime date);
        IntervalAdminResultDto IntervalGets(DateTime date);
        IntervalAdminResultMapDto IntervalGetsMap(DateTime date);
    }
}
