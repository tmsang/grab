using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tmsang.application
{
    public interface IGuestOrderService
    {
        Task<string> GetPrice();
        Task<BookResultDto> Book(BookDto bookDto);
        Task<IntervalGuestResultDto> IntervalGets(string lat, string lng, Guid orderId);        
        Task Cancel(string requestId, string reason);
        Task Evaluable(EvaluableDto evaluableDto);

        Task<StatisticDto> Statistic();
        Task<IEnumerable<GuestRequestHistoryDto>> RequestHistories();
    }
}
