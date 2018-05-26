using iTemo.Data.Repository.Interface;

namespace iTemo.Data.Repository.Implementation
{
    public class ProductRepository : EntityRepository<Product>, IProductRepository
    {
        public ProductRepository(IEntitiesContext context)
            : base(context)
        {
        }
    }
}
