using System.Collections.Generic;

namespace tmsang.application
{
    public interface IGuestOrderService
    {
        void Book(BookDto bookDto);
        void Cancel(string requestId);
        void Evaluable(EvaluableDto evaluableDto);
        IList<TransactionHistoriesDto> TransactionHistories(string accountId);
    }
}
