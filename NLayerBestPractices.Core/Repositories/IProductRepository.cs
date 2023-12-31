﻿using NLayerBestPractices.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerBestPractices.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product> 
    {
        Task<List<Product>> GetProductsWithCategoryAsync();
    }
}
