using NLayerBestPractices.Core.Entities;

namespace NLayerBestPractices.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategoryAsync();
    }
}
