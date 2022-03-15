using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tmsang.api.Controllers
{   
    [Authorize]
    [Route("api/driver/log")]
    public class DriverLogController : Controller
    {

        [HttpPost("")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
                return Ok(new { length = file.Length, name = file.FileName });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
