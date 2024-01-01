using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerBestPractices.Core.Entities;

namespace NLayerBestPratices.Repository.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Stifte" },
                new Category { Id = 2, Name = "Bücher" },
                new Category { Id = 3, Name = "Hefte" });
        }
    }
}
