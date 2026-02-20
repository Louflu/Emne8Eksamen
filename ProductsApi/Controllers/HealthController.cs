using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : Controller
    {

        private readonly ProductContext context;
        public HealthController(ProductContext context)
        {
            this.context = context;
        }

        //healthcheck endpoint api kall
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> HealthCheckAsync()
        {
            return Ok("API OK");
        }
    }
}
