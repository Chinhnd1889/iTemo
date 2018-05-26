using iTemo.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace iTemo.Data.Repository.Implementation
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntityBase
    {
        #region Private Variables

        protected readonly IEntitiesContext Context;
        private readonly int? _currentUserId;
        private IEnumerable<string> _currentUserProfileRoles;
        private int _numberEvent = 0;

        #endregion

        #region Constructors

        protected EntityRepository(IEntitiesContext context)
        {
            Context = context;
        }

        #endregion

        #region Public Properties

        public int? CurrentUserId { get { return _currentUserId; } }

        public IEnumerable<string> CurrentUserProfileRoles => throw new NotImplementedException();

        #endregion

        #region Public Methods

        public int CommitChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> CommitChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public T Delete(T entity)
        {
            if (entity == null) return null;
            entity.IsDeleted = true;

            if (Context.Entry(entity) != null)
            {
                Context.Entry(entity).State = EntityState.Modified;
            }
            return entity;
        }

        public void DeleteByCondition(Func<T, bool> expression)
        {
            foreach (var record in Context.Set<T>().Where(expression))
            {
                record.IsDeleted = true;
            }
        }

        public T Get(int key)
        {
            return Context.Set<T>().Find(key);
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public IQueryable<T> GetAllNonDelete()
        {
            return Context.Set<T>().Where(m => !m.IsDeleted);
        }

        public async Task<T> GetAsync(int key)
        {
            return await Context.Set<T>().FindAsync(key);
        }

        public IQueryable GetByDynamicCondition(string whereCondition, string selectCondition)
        {
            throw new NotImplementedException();
        }

        public T Insert(T entity)
        {
            if (entity == null) return null;
            if (Context != null && Context.Entry(entity) != null)
                Context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public T ReActive(T entity)
        {
            entity.IsDeleted = false;
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public T Refresh(T entity)
        {
            if (entity == null) return null;
            Context?.Entry(entity).Reload();
            return entity;
        }

        public T Update(T entity)
        {
            if (entity != null)
            {
                if (Context.Entry(entity) != null)
                    Context.Entry(entity).State = EntityState.Modified;
                return entity;
            }
            return null;
        }

        public IEnumerable<T> Update(IEnumerable<T> entities, string primaryKey, int primaryKeyValue)
        {
            throw new NotImplementedException();
        }

        protected virtual void TriggerChange(ICollection<DbEntityEntry> entries)
        {
            var tasks = new List<Task>();
            //tasks.Add(AuditTrails(entries));
            //tasks.Add(AuditChanges(entries));
            //Task.WhenAll(tasks);
        }

        #endregion
    }
}
