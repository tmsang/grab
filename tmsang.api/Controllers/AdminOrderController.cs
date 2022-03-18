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

        [HttpGet("zalo-call")]
        public void ZaloCall(string zaloUserId)
        {
            try
            {
                this.orderService.ZaloCall(zaloUserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Mobile Service will snipt 10s to get [driver position, order status]
        [HttpGet("interval-gets")]
        public IntervalAdminResultDto IntervalAdminGetsAsync(long date)
        {
            try
            {                         
                DateTime toDateTime = new DateTime(date).AddHours(7);                
                return this.orderService.IntervalGets(toDateTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
