using iTemo.Data.Repository.Implementation;
using System;

namespace iTemo.Data.Infrastructure
{
    public interface IiTemoUnitOfWork : IDisposable
    {
        #region Properties

        ProductRepository ProductRepository { get; }
        CategoryRepository CategoryRepository { get; }
        UserRepository UserRepository { get; }
        RoleRepository RoleRepository { get; }
        UserRoleRepository UserRoleRepository { get; }

        #endregion

        #region Methods

        void Commit();
        void CommitAsync();

        #endregion
    }
}
