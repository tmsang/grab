using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpPost("accept")]
        public void AcceptBooking(Guid orderId)
        {
            try
            {
                this.orderService.AcceptAsync(orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("start")]
        public void Start(Guid orderId)
        {
            try
            {
                this.orderService.Start(orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("end")]
        public void End(Guid orderId)
        {
            try
            {
                this.orderService.End(orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("transaction-histories")]
        public IEnumerable<DriverTransactionHistoriesDto> TransactionHistories()
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
