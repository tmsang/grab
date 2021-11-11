using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tmsang.application;

namespace tmsang.api
{
    [Authorize]
    [Route("api/guest/order")]
    public class GuestOrderController: Controller
    {
        readonly IGuestOrderService orderService;

        public GuestOrderController(IGuestOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost("book")]
        public void Book(BookDto bookDto)
        {
            try
            {
                this.orderService.Book(bookDto);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("cancel-by-client")]
        public void Cancel(string requestId)
        {
            try
            {
                this.orderService.Cancel(requestId);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("evaluable")]
        public void Evaluable(EvaluableDto evaluableDto)
        {
            try
            {
                this.orderService.Evaluable(evaluableDto);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("transaction-histories")]
        public IList<TransactionHistoriesDto> TransactionHistories(string accountId)
        {
            try
            {
                return this.orderService.TransactionHistories(accountId);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
