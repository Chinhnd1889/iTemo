using iTemo.Core.Attribute;
using iTemo.Data.Metadata;
using iTemo.Data.Repository.Interface;

namespace iTemo.Data
{
    [TrackChanges("Category")]
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category : IEntityBase
    {

    }
}
