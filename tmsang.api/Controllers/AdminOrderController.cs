using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tmsang.application;

namespace tmsang.api.Controllers
{
    [Authorize]
    [Route("api/admin/order")]
    public class AdminOrderController : Controller
    {
        readonly IAdminOrderService orderService;

        public AdminOrderController(IAdminOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("requests")]
        public IEnumerable<AdminRequestDto> Requests()
        {
            try
            {
                return this.orderService.RequestsByDate(new DateTime(2022, 3, 10));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Mobile Service will snipt 10s to get [driver position, order status]
        [HttpGet("interval-gets")]
        public IntervalAdminResultDto IntervalAdminGetsAsync()
        {
            try
            {
                return this.orderService.IntervalGets();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
