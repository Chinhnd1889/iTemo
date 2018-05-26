using System;

namespace iTemo.Data.Repository.Interface
{
    public interface IEntityBase
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
        int? CreatedById { get; set; }
        DateTime? CreatedOn { get; set; }
        int? ModifiedById { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
