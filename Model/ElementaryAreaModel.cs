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
        public int RegionId { get; set; }
        [RelationColumn(
            ReferenceId = "Регион",
            FromTable = "_Регионы",
            PurposeId = "ID",
            FromColumn = "Name"]
        )]
        public string Region { get; set; }
        [Column("Действующий")]
        public bool Active { get; set; }
        [Column("SoilKind")]
        public int SoilKindId { get; set; }
        [RelationColumn(
            ReferenceId = "SoilKind", 
            FromTable = "_ВидПочвы",
            PurposeId = "ID",
            FromColumn = "TypeName"
        )]
        public string SoilKind { get; set; }
        [Column("SoilClass")]
        public int SoilClassId { get; set; }
        [RelationColumn(
            ReferenceId = "SoilClass",
            FromTable = "_КлассПочвы",
            PurposeId = "ID",
            FromColumn = "TypeName"
        )]
        public string SoilClass { get; set; }
        [Column("SoilType")]
        public int SoilTypeId { get; set; }
        [RelationColumn(
            ReferenceId = "SoilType",
            FromTable = "_ТипыПочвы",
            PurposeId = "ID",
            FromColumn = "TypeName"
        )]
        public string SoilType { get; set; }
    }
}
