using System.Collections.Generic;
using System.Threading.Tasks;

namespace tmsang.application
{
    public interface IGuestOrderService
    {
        Task Book(BookDto bookDto);
        Task Cancel(string requestId, string reason);
        Task Evaluable(EvaluableDto evaluableDto);
        Task<IEnumerable<GuestTransactionHistoriesDto>> TransactionHistories();
    }
}
