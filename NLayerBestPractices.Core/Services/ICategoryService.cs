using NLayerBestPractices.Core.Dtos;
using NLayerBestPractices.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NLayerBestPractices.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> GetCatergoryWithProductsAsync(int id);
    }
}
