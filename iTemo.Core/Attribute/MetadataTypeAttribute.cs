using System;

namespace iTemo.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class MetadataTypeAttribute : System.Attribute
    {
        public Type MetadataClassType { get; set; }

        public string Property { get; set; }

        public MetadataTypeAttribute(Type metadataClassType)
        {
            this.MetadataClassType = metadataClassType;
        }

        public MetadataTypeAttribute(Type metadataClassType, string property)
        {
            this.MetadataClassType = metadataClassType;
            this.Property = property;
        }
    }
}
