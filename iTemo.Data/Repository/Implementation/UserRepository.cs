using iTemo.Data.Repository.Interface;

namespace iTemo.Data.Repository.Implementation
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(IEntitiesContext context) 
            : base(context)
        {
        }
    }
}
