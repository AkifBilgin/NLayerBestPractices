using AutoMapper;
using NLayerBestPractices.Core.Dtos;
using NLayerBestPractices.Core.Entities;
using NLayerBestPractices.Core.Repositories;
using NLayerBestPractices.Core.Services;
using NLayerBestPractices.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerBestPractices.Service.Services
{
    public class ProductServiceWithNoCaching : Services<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductServiceWithNoCaching(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoryAsync()
        {
            var product = await _productRepository.GetProductsWithCategoryAsync();
            var producDto = _mapper.Map<List<ProductWithCategoryDto>>(product);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, producDto);
            
           
        }
    }
}
