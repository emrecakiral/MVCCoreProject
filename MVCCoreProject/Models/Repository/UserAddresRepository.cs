using MVCCoreProject.Models.Entities;
using MVCCoreProject.Models.Specification;

namespace MVCCoreProject.Models.Repository
{
    public class UserAddresRepository : IRepository<UserAddres>, ISpecification<UserAddres>
    {
        private readonly NorthwindDbContext _dbContext;
        public UserAddresRepository(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(UserAddres item)
        {
            _dbContext.UserAddres.Add(item);
            _dbContext.SaveChanges();
            return 1;
        }

        public int Delete(UserAddres item)
        {
            item.Active = false;
            _dbContext.SaveChanges(); 
            return 1;
        }
        // Bütün adreslerini getirmek için....
        public List<UserAddres> FindByCriter(Func<UserAddres, bool> expression)
        {
            return _dbContext.UserAddres.Where(expression).ToList();
        }

        public UserAddres Get(int id)
        {
            return _dbContext.UserAddres.Find(id);
        }

        public List<UserAddres> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(UserAddres item)
        {
            throw new NotImplementedException();
        }
    }
}
