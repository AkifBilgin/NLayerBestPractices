using NLayerBestPractices.Core.Dtos;
using NLayerBestPractices.Core.Entities;

namespace NLayerBestPractices.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<List<ProductWithCategoryDto>> GetProductsWithCategoryAsync();
    }
}
