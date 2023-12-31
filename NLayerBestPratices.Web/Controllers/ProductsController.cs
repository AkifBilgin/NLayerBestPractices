using Microsoft.AspNetCore.Mvc;
using NLayerBestPractices.Core.Services;


namespace NLayerBestPratices.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
           var products = await _productService.GetProductsWithCategoryAsync();
            return View(products);
        }
    }
}
