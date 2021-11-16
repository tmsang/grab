using System.Collections.Generic;

namespace tmsang.application
{
    public interface IGuestOrderService
    {
        void Book(BookDto bookDto);
        void Cancel(string requestId, string reason);
        void Evaluable(EvaluableDto evaluableDto);
        IEnumerable<GuestTransactionHistoriesDto> TransactionHistories();
    }
}
