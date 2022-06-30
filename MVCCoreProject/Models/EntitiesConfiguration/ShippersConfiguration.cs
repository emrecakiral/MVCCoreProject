using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCoreProject.Models.Entities;

namespace MVCCoreProject.Models.EntitiesConfiguration
{
    // IEntityTypeConfiguration => tablo ile class arasında mapping yapmak için kullanılan interface'dir...

    // Fluent Api yöntemi ile db sınıfları configure edilirken modelCreating metodu yerine configuration dosyaları oluşturup bu işlemi yapmak daha iyidir..
    public class ShippersConfiguration : IEntityTypeConfiguration<Shippers>
    {
        public void Configure(EntityTypeBuilder<Shippers> builder)
        {
            builder.HasKey(c => c.ShippersId);
            builder.Property(c => c.ShippersId).HasColumnName("ShipperId");
            builder.Property(c => c.Company).HasColumnName("CompanyName");
            // c.ExcludeFromMigrations()=> migration'a dahil etme..
            builder.ToTable("Shippers",c=> c.ExcludeFromMigrations());
        }
    }
}
