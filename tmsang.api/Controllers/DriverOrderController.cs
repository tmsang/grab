using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tmsang.application;

namespace tmsang.api
{

    // ===================================================
    // Driver just accept Booking - khong cho phep huy, khong cho so sanh gia, khoang cach
    // Driver chi nhan hay khong nhan mot cai Book
    // ===================================================

    [Authorize]
    [Route("api/driver/order")]
    public class DriverOrderController : Controller
    {
        readonly IDriverOrderService orderService;

        public DriverOrderController(IDriverOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("requests")]
        public async Task<IEnumerable<GuestRequestDto>> GuestRequestsAsync()
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

        [HttpPost("accept")]
        public async Task AcceptBookingAsync(Guid orderId)
        {
            try
            {
                await this.orderService.AcceptAsync(orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("start")]
        public async Task StartAsync(Guid orderId)
        {
            try
            {
                await this.orderService.Start(orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("end")]
        public async Task EndAsync(Guid orderId)
        {
            try
            {
                await this.orderService.End(orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("transaction-histories")]
        public async Task<IEnumerable<DriverTransactionHistoriesDto>> TransactionHistoriesAsync()
        {
            try
            {
                return await this.orderService.TransactionHistories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
