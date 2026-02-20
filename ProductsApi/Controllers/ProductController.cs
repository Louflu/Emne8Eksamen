using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductContext context;
        public ProductsController(ProductContext context)
        {
            this.context = context;
        }

        // get product list
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProductList()
        {
            var products = context.Products.ToList();

            return Ok(products);
        }

        // get product by id
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProductById(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(product);
        }
    }

}
