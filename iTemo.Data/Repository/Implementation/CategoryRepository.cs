using iTemo.Data.Repository.Interface;

namespace iTemo.Data.Repository.Implementation
{
    public class CategoryRepository : EntityRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IEntitiesContext context) 
            : base(context)
        {

        }
    }
}
