using Microsoft.EntityFrameworkCore;
using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Specification;

namespace MVCCoreProject.Models.Repository
{
    public class ProductsRepository : IRepository<Products>, ISpecification<Products>
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

        public List<Products> FindByCriter(Func<Products, bool> expression)
        {
            return dbContext.Products.Where(expression).ToList();
        }

        public Products Get(int id)
        {
            return dbContext.Products.Include(c => c.Category).FirstOrDefault(c => c.ProductID == id);
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



        // spesific metodu buraya yazabiliriz. Ancak buraya yazdığımızda o metota başka bir repository'de ihtiyacımız olabilir. Bu yüzden bu tür işlemler için yeni bir interface üzerinden metodu alıp implement edelim..(İlgili yapı Specification folderındadır)
    }
}
