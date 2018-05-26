using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace iTemo.Data
{
    public partial class iTemoContext : IEntitiesContext
    {
        public Action<ICollection<DbEntityEntry>> TriggerChange { get; set; }
        public List<string> SystemLogData { get; set; }
    }
}
