using iTemo.Data.Repository.Interface;

namespace iTemo.Data.Repository.Implementation
{
    public class RoleRepository:EntityRepository<Role>, IRoleRepository
    {
        public RoleRepository(IEntitiesContext context)
            : base(context)
        {
        }
    }
}
