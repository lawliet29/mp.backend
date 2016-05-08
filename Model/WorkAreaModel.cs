using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("агроном_РабочиеУчастки")]
    public class WorkAreaModel
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Number")]
        public string Number { get; set; }
    }
    [Table("агроном_РабочиеУчастки")]
    public class WorkAreaFullModel : WorkAreaModel
    {
        [Column("Действующий")]
        public bool Active { get; set; }
    }
}
