using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCoreProject.Models.Entities;

namespace MVCCoreProject.Models.EntitiesConfiguration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("RegionId");
            builder.Property(c => c.Description).HasColumnName("RegionDescription").HasColumnType("nvarchar").HasMaxLength(50);

            builder.ToTable("Region",c=> c.ExcludeFromMigrations());
        }
    }
}
