using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace iTemo.Data
{
    public interface IEntitiesContext
    {
        Action<ICollection<DbEntityEntry>> TriggerChange { get; set; }

        DbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        DbEntityEntry Entry(object entity);

        Database Database { get; }

        List<string> SystemLogData { get; set; }
    }
}
