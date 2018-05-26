using iTemo.Core.Attribute;

namespace iTemo.Data.Metadata
{
    public class RoleMetadata
    {
        [AuditLog(LogType.Data, "Name")]
        public string Name { get; set; }
    }
}
