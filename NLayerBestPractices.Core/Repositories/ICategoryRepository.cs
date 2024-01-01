using NLayerBestPractices.Core.Entities;

namespace NLayerBestPractices.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryWithProductsAsync(int id);
    }
}
