using MVCCoreProject.Models.Entities;
using System.Linq;

namespace MVCCoreProject.Models.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        NorthwindDbContext dbContext;
        public CustomerRepository(NorthwindDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public int Add(Customer item)
        {
            dbContext.Customer.Add(item);
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

        public int Delete(Customer item)
        {
            dbContext.Customer.Remove(item);

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



        public Customer Get(int id)
        {
            return dbContext.Customer.FirstOrDefault(c => c.id == id.ToString());
        }

        public List<Customer> GetAll()
        {
            return dbContext.Customer.ToList();
        }

        public int Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
