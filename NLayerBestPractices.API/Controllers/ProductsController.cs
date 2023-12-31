using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerBestPractices.API.Filters;
using NLayerBestPractices.Core.Dtos;
using NLayerBestPractices.Core.Entities;
using NLayerBestPractices.Core.Services;

namespace NLayerBestPractices.API.Controllers
{
   
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;

        private readonly IProductService _productService;
        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategoryAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            var productDto = _mapper.Map<List<ProductDto>>(products.ToList());
            // return Ok(CustomResponseDto<List<ProductDto>>.Success(200,productDto));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productService.AddAsync(product);
            var productResponse = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productResponse));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productService.UpdateAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            await _productService.RomoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
