using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            return Ok();
        }

        // healthcheck endpoint for databasen 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> DatabaseHealthCheckAsync()
        {
            try
            {
                var canConnect = await context.Database.CanConnectAsync();
                if (canConnect)
                {
                    return Ok("Database is healthy.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Database is not reachable.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, $"Database health check failed: {ex.Message}");
            }
        }
    }
}
