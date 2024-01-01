﻿using Microsoft.EntityFrameworkCore;
using NLayerBestPractices.Core.Entities;
using NLayerBestPractices.Core.Repositories;

namespace NLayerBestPratices.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategoryAsync()
        {
            return await _context.Products.Include(c => c.Category).ToListAsync();
        }
    }
}
