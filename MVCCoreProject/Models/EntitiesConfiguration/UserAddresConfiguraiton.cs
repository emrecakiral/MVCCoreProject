using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCoreProject.Models.Entities;

namespace MVCCoreProject.Models.EntitiesConfiguration
{
    public class UserAddresConfiguraiton : IEntityTypeConfiguration<UserAddres>
    {
        public void Configure(EntityTypeBuilder<UserAddres> builder)
        {
            builder.ToTable("UserAddress");
        }
    }
}