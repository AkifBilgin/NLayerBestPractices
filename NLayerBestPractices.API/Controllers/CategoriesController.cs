using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerBestPractices.API.Filters;
using NLayerBestPractices.Core.Dtos;
using NLayerBestPractices.Core.Services;

namespace NLayerBestPractices.API.Controllers
{
  
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCategoryWithProductsAsync(int id)
        {
            return CreateActionResult(await _categoryService.GetCatergoryWithProductsAsync(id));  
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoriesDto));
        }
    }
}
