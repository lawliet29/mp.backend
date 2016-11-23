using System;

namespace Backend.Metadata
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RelationColumnAttribute : Attribute
    {
        public string FromTable { get; set; }
        public string ReferenceId { get; set; }
        public string RemoteId { get; set; }
        public string FromColumn { get; set; } 
    }
}
