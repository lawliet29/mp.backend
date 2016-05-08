using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Metadata;

namespace Backend.Model
{
    [Table("агроном_ЭлементарныеУчастки")]
    public class ElementaryAreaModel
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Number")]
        public int Number { get; set; }
    }
    [Table("агроном_ЭлементарныеУчастки")]
    public class ElementaryAreaFullModel : ElementaryAreaModel
    {
        [Column("S")]
        public int PlanarArea { get; set; }
        [Column("Регион")]
        public int Region { get; set; }
        [Column("Действующий")]
        public bool Active { get; set; }
        [Column("SoilKind")]
        public int SoilKind { get; set; }
        [Column("SoilClass")]
        public int SoilClass { get; set; }
        [Column("SoilType")]
        public int SoilType { get; set; }
    }
}
