using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductContext context;
        public ProductController(ProductContext context)
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
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProductListById(int? productid = null)
        {
            var products = context.Products;

            try
            {
                IQueryable<ProductItem> filtered = products;
                if (productid != null)
                {
                    filtered = filtered.Where(p => p.Id == productid);
                }

                var count = filtered.Count();
                if (count == 0)
                {
                    return NotFound($"No results found with parameters given: {productid}");
                }
                return Ok(filtered.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest("something went wrong");
            }
        }
    }

}
