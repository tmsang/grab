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
        public async Task BookAsync(BookDto bookDto)
        {
            try
            {
                await this.orderService.Book(bookDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("driver-positions")]
        public async Task<IEnumerable<DriverPositionDto>> GetDriverPositionsAsync(string lat, string lng)
        {
            try
            {
                return await this.orderService.GetDriverPositions(lat, lng);
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

        

        [HttpGet("requests")]
        public async Task<IEnumerable<GuestRequestHistoryDto>> Requests()
        {
            try
            {
                return await this.orderService.Requests();
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

    }
}
