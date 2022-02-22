using System.Collections.Generic;
using System.Threading.Tasks;

namespace tmsang.application
{
    public interface IGuestOrderService
    {
        Task<string> GetPrice();
        Task Book(BookDto bookDto);
        Task<IEnumerable<DriverPositionDto>> GetDriverPositions(string lat, string lng);        
        Task Cancel(string requestId, string reason);
        Task Evaluable(EvaluableDto evaluableDto);
        Task<IEnumerable<GuestTransactionHistoriesDto>> TransactionHistories();
    }
}
