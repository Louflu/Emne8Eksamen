using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductContext context;
        private readonly CloudWatchMetricsService cloudWatchMetricsService;
        public ProductsController(ProductContext context, CloudWatchMetricsService cloudWatchMetricsService)
        {
            this.context = context;
            this.cloudWatchMetricsService = cloudWatchMetricsService;
        }

        // get product list
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductList()
        {
            await cloudWatchMetricsService.SendApiCallMetricAsync();

            var products = context.Products.ToList();

            return Ok(products);
        }

        // get product by id
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductById(int id)
        {
            await cloudWatchMetricsService.SendApiCallMetricAsync();

            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(product);
        }
    }

}
