using MVCCoreProject.Models.Entities;

namespace MVCCoreProject.Models.Repository
{
    public class ProductDiscountRepository : IRepository<ProductDiscount>
    {

        readonly NorthwindDbContext _dbContext;
        public ProductDiscountRepository(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(ProductDiscount item)
        {
            throw new NotImplementedException();
        }

        public int Delete(ProductDiscount item)
        {
            throw new NotImplementedException();
        }

        public ProductDiscount Get(int id)
        {
            return _dbContext.ProductDiscount.FirstOrDefault(c => c.ProductId == id);
        }

        public List<ProductDiscount> GetAll()
        {
            return _dbContext.ProductDiscount.ToList();
        }

        public int Update(ProductDiscount item)
        {
            throw new NotImplementedException();
        }
    }
}