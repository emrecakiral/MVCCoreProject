using MVCCoreProject.Models.Entities;

namespace MVCCoreProject.Models.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        NorthwindDbContext dbContext;
        public CategoryRepository(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public int Add(Category item)
        {
            dbContext.Category.Add(item);
            try
            {
                dbContext.SaveChanges();// değişikliği veritabanına yansıt...
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public int Delete(Category item)
        {
            dbContext.Category.Remove(item);

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

        public Category Get(int id)
        {
            return dbContext.Category.Find(id);
        }

        public List<Category> GetAll()
        {
            return dbContext.Category.ToList();
        }

        public int Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
