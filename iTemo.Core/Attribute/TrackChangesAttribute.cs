using System;

namespace iTemo.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class TrackChangesAttribute : System.Attribute
    {
        public string Name { get; set; }
        public string Property { get; set; }
        public string FilterProperty { get; set; }
        public object[] FilterPropertyValues { get; set; }
        public bool LogWhenDelete { get; set; }

        public TrackChangesAttribute(string name)
        {
            this.Name = name;
        }

        public TrackChangesAttribute(string name, string property)
        {
            this.Name = name;
            this.Property = property;
        }

        public TrackChangesAttribute(string name, string property, string filterProperty, object[] filterPropertyValues)
        {
            this.Name = name;
            this.Property = property;
            this.FilterProperty = filterProperty;
            this.FilterPropertyValues = filterPropertyValues;
        }

        public TrackChangesAttribute(string name, string property, bool logWhenDelete)
        {
            this.Name = name;
            this.Property = property;
            this.LogWhenDelete = logWhenDelete;
        }
    }
}
