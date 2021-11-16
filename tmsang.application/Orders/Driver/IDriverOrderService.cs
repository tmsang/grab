using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tmsang.application
{
    public interface IDriverOrderService
    {
        Task AcceptAsync(Guid orderId);
        Task Start(Guid orderId);
        Task End(Guid orderId);
        Task<IEnumerable<DriverTransactionHistoriesDto>> TransactionHistories();
    }
}
