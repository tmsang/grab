using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpGet("price")]
        public async Task<string> GetPriceAsync()
        {
            try
            {
                return await this.orderService.GetPrice();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("book")]
        public async Task<BookResultDto> BookAsync(BookDto bookDto)
        {
            try
            {
                return await this.orderService.Book(bookDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [HttpPost("cancel-by-client")]
        public async Task CancelAsync(string requestId, string reason)
        {
            try
            {
                await this.orderService.Cancel(requestId, reason);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpGet("statistic")]
        public async Task<StatisticDto> Statistic()
        {
            try
            {
                return await this.orderService.Statistic();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("request-histories")]
        public async Task<IEnumerable<GuestRequestHistoryDto>> RequestHistories()
        {
            try
            {
                return await this.orderService.RequestHistories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("evaluable")]
        public async Task EvaluableAsync(EvaluableDto evaluableDto)
        {
            try
            {
                await this.orderService.Evaluable(evaluableDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Mobile Service will snipt 10s to get [driver position, order status]
        [HttpGet("interval-gets")]
        public async Task<IntervalGuestResultDto> IntervalGuestGetsAsync(string lat, string lng, Guid orderId)
        {
            try
            {
                return await this.orderService.IntervalGets(lat, lng, orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
