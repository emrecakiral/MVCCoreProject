using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCoreProject.Models.Entities;

namespace MVCCoreProject.Models.EntitiesConfiguration
{
    public class ProductDiscountConfiguraiton : IEntityTypeConfiguration<ProductDiscount>
    {
        public void Configure(EntityTypeBuilder<ProductDiscount> builder)
        {
            builder.HasKey(c => c.ProductId);
        }
    }
}
