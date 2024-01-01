using NLayerBestPractices.Core.Dtos;
using NLayerBestPractices.Core.Entities;

namespace NLayerBestPractices.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> GetCatergoryWithProductsAsync(int id);
    }
}
