using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        // Allow anonymous requests to allow health checks without authentication
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            // Return simple JSON indicating health status
            return Ok(new { status = "Healthy" });
        }
    }
}