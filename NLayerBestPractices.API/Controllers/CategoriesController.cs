using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerBestPractices.Core.Services;

namespace NLayerBestPractices.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCategoryWithProductsAsync(int id)
        {
            return CreateActionResult(await _categoryService.GetCatergoryWithProductsAsync(id));  
        }
    }
}
