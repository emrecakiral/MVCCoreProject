using Microsoft.EntityFrameworkCore;
using MVCCoreProject.Models.EntitiesConfiguration;

namespace MVCCoreProject.Models.Entities
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
     //   public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
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
