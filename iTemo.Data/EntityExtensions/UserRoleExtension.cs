using iTemo.Core.Attribute;
using iTemo.Data.Metadata;
using iTemo.Data.Repository.Interface;

namespace iTemo.Data
{
    [TrackChanges("UserRole")]
    [MetadataType(typeof(UserRoleMetadata))]
    public partial class UserRole : IEntityBase
    {
    }
}
