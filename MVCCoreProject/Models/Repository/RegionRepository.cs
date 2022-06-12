using MVCCoreProject.Models.Entities;

namespace MVCCoreProject.Models.Repository
{
    public class RegionRepository : IRepository<Region>
    {
        NorthwindDbContext dbContext;
        public RegionRepository(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public int Add(Region item)
        {
            dbContext.Region.Add(item);
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

        public int Delete(Region item)
        {
            dbContext.Region.Remove(item);
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

        public Region Get(int id)
        {
            return dbContext.Region.Find(id);
        }

        public List<Region> GetAll()
        {
            return dbContext.Region.ToList();
        }

        public int Update(Region item)
        {
            throw new NotImplementedException();
        }
    }
}
