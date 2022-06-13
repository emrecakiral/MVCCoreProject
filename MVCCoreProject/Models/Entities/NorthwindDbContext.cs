using Microsoft.EntityFrameworkCore;
using MVCCoreProject.Areas.Manage.Models.ViewModels;
using MVCCoreProject.Models.EntitiesConfiguration;

namespace MVCCoreProject.Models.Entities
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
        }
        //   public DbSet<Customer> Customer { get; set; }

        public DbSet<ProductsViewModel>? ProductsViewModel { get; set; }
     //   public DbSet<Customer> Customer { get; set; }

    }


    // Base sinifa ctroda parametre gönderme örneki
    //public class BaseSinif
    //{
    //    string isim;
    //    public BaseSinif(string i)
    //    {
    //        isim = i;
    //    }
    //    public void Goster()
    //    {
    //        Console.WriteLine(isim);
    //    }
    //}

    //public class AltSinif : BaseSinif
    //{
    //    public AltSinif(string str) : base(str)
    //    {
    //    }
    //}

}
