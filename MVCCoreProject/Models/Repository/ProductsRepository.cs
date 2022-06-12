using MVCCoreProject.Models.Entities;

namespace MVCCoreProject.Models.Repository
{
    public class ProductsRepository : IRepository<Products>
    {
        NorthwindDbContext dbContext;

        public ProductsRepository(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext; 
        }

        public int Add(Products item)
        {
            dbContext.Products.Add(item);
            try
            {
                dbContext.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(Products item)
        {
            dbContext.Products.Remove(item);
            try
            {
                dbContext.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public Products Get(int id)
        {
            return dbContext.Products.Find(id);
        }

        public List<Products> GetAll()
        {
            return dbContext.Products.ToList();
        }

        public int Update(Products item)
        {
            dbContext.Products.Update(item);
            try
            {
                dbContext.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
