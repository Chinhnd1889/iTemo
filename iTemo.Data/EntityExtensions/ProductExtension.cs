using iTemo.Core.Attribute;
using iTemo.Data.Metadata;
using iTemo.Data.Repository.Interface;

namespace iTemo.Data
{
    [TrackChanges("Product")]
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product : IEntityBase
    {

    }
}
