using iTemo.Core.Attribute;
using iTemo.Data.Metadata;
using iTemo.Data.Repository.Interface;

namespace iTemo.Data
{
    [TrackChanges("Role")]
    [MetadataType(typeof(RoleMetadata))]
    public partial class Role : IEntityBase
    {
    }
}
