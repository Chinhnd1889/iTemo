using iTemo.Data.Repository.Implementation;

namespace iTemo.Data.Infrastructure
{
    public class iTemoUnitOfWork : IiTemoUnitOfWork
    {
        #region Private Variables

        private readonly IEntitiesContext _context;

        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        private UserRepository _userRepository;
        private UserRoleRepository _userRoleRepository;
        private RoleRepository _roleRepository;

        #endregion

        #region Constructors

        public iTemoUnitOfWork(IEntitiesContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Properties

        public ProductRepository ProductRepository
        {
            get
            {
                if(_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            }
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public UserRoleRepository UserRoleRepository
        {
            get
            {
                if (_userRoleRepository == null)
                {
                    _userRoleRepository = new UserRoleRepository(_context);
                }
                return _userRoleRepository;
            }
        }

        public RoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleRepository(_context);
                }
                return _roleRepository;
            }
        }

        #endregion

        #region Public Methods

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void CommitAsync()
        {
            _context.SaveChangesAsync();
        }

        public void Dispose()
        {

        }

        #endregion
    }
}
