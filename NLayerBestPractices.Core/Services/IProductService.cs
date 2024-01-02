using NLayerBestPractices.Core.Dtos;
using NLayerBestPractices.Core.Entities;

namespace NLayerBestPractices.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoryAsync();
    }
}
