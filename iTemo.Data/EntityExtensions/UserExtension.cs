using iTemo.Core.Attribute;
using iTemo.Data.Metadata;
using iTemo.Data.Repository.Interface;

namespace iTemo.Data
{
    [TrackChanges("User")]
    [MetadataType(typeof(UserMetadata))]
    public partial class User : IEntityBase
    {
    }
}