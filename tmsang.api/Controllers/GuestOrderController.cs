using Microsoft.AspNetCore.Mvc;
using System;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("cancel-by-client")]
        public void Cancel(string requestId, string reason)
        {
            try
            {
                this.orderService.Cancel(requestId, reason);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("evaluable")]
        public void Evaluable(EvaluableDto evaluableDto)
        {
            try
            {
                this.orderService.Evaluable(evaluableDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("transaction-histories")]
        public IEnumerable<TransactionHistoriesDto> TransactionHistories()
        {
            try
            {
                return this.orderService.TransactionHistories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
