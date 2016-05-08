using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Metadata
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RelationColumnAttribute : Attribute
    {
        public string FromTable { get; set; }
        public string ReferenceId { get; set; }
        public string PurposeId { get; set; }
        public string FromColumn { get; set; } 
    }
}
