using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTemo.Data.Repository.Interface
{
    public interface IEntityRepository<T> where T : IEntityBase
    {
        int? CurrentUserId { get; }
        IEnumerable<string> CurrentUserProfileRoles { get; }
        IQueryable<T> GetAll();
        IQueryable<T> GetAllNonDelete();
        IQueryable GetByDynamicCondition(string whereCondition, string selectCondition);
        Task<T> GetAsync(int key);
        T Get(int key);
        T Insert(T entity);
        T Update(T entity);
        T Refresh(T entity);
        IEnumerable<T> Update(IEnumerable<T> entities, string primaryKey, int primaryKeyValue);
        T Delete(T entity);
        void DeleteByCondition(Func<T, bool> expression);
        int CommitChanges();
        Task<int> CommitChangesAsync();
        T ReActive(T entity);
    }
}
