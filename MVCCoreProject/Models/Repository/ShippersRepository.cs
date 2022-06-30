using MVCCoreProject.Models.Entities;

namespace MVCCoreProject.Models.Repository
{
    public class ShippersRepository : IRepository<Shippers>
    {
        NorthwindDbContext dbContext;
        public ShippersRepository(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public int Add(Shippers item)
        {
            throw new NotImplementedException();
        }

        public int Delete(Shippers item)
        {
            throw new NotImplementedException();
        }

        public Shippers Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Shippers> GetAll()
        {
            return dbContext.Shippers.ToList();
        }

        public int Update(Shippers item)
        {
            throw new NotImplementedException();
        }
    }
}
