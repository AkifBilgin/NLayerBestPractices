using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayerBestPractices.Core.Dtos;
using NLayerBestPractices.Core.Entities;
using NLayerBestPractices.Core.Services;
using NLayerBestPratices.Web.Services;

namespace NLayerBestPratices.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;

        public ProductController(ProductApiService productApiService, CategoryApiService categoryApiService)
        {
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetProductsWithCategoryAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Save()
        {
            var categories = await _categoryApiService.GetAllCategoriesAync();

            ViewBag.categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {


            if (ModelState.IsValid)
            {
                await _productApiService.SaveAsync(productDto);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryApiService.GetAllCategoriesAync();

            ViewBag.categories = new SelectList(categories, "Id", "Name");
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            var categories = await _categoryApiService.GetAllCategoriesAync();

            ViewBag.categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }
       // [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.Update(productDto);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryApiService.GetAllCategoriesAync();

            ViewBag.categories = new SelectList(categories, "Id", "Name");
            return View(productDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productApiService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
