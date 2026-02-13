using Microsoft.AspNetCore.Mvc;

namespace ProductsApi.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
