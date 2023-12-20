using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerBestPractices.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerBestPratices.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = 1, Price = 5, Stock = 20, CreatedDate = DateTime.Now, Name = "Kugelschreiber" },
                new Product { Id = 2, CategoryId = 2, Price = 5, Stock = 20, CreatedDate = DateTime.Now, Name = ".Net8 " },
                new Product { Id = 3, CategoryId = 2, Price = 5, Stock = 20, CreatedDate = DateTime.Now, Name = "Rich Dad Poor Dad" });
        }
    }
}
