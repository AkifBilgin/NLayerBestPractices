using Microsoft.EntityFrameworkCore;
using NLayerBestPractices.Core.Entities;
using NLayerBestPractices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerBestPratices.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryWithProductsAsync(int id)
        {
            return await _context.Categories.Include(p => p.Products).Where(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}
