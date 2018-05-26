using iTemo.Data.Repository.Interface;

namespace iTemo.Data.Repository.Implementation
{
    public class UserRoleRepository : EntityRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IEntitiesContext context)
            : base(context)
        {
        }
    }
}
