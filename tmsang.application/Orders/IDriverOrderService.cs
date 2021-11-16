using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tmsang.application
{
    public interface IDriverOrderService
    {
        void AcceptAsync(Guid orderId);
        void Start(Guid orderId);
        void End(Guid orderId);
        IEnumerable<DriverTransactionHistoriesDto> TransactionHistories();
    }
}
