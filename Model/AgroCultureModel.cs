using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Metadata;

namespace Backend.Model
{
    [Table("агроном_АгроКультуры")]
    public class AgroCultureModel
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
    }
    [Table("агроном_АгроКультуры")]
    public class AgroCultureFullModel : AgroCultureModel
    {
        [Column("AddedByUser")]
        public bool AddedByUser { get; set; }
        [Column("ProductionType")]
        public int ProductionTypeId { get; set; }
        [RelationColumn(
            ReferenceId = "ProductionType",
            FromTable = "_АгроКультуры_ПроизводственныеТипы",
            PurposeId = "ID",
            FromColumn = "NameOfType"
        )]
        public string ProductionType { get; set; }
        [Column("BiologicalType")]
        public int BiologicalTypeId { get; set; }
        [RelationColumn(
            ReferenceId = "BiologicalType",
            FromTable = "_АгроКультуры_БиологическиеТипы",
            PurposeId = "ID",
            FromColumn = "NameOfType"
        )]
        public string BiologicalType { get; set; }
        [Column("Intermediate")]
        public bool Intermediate { get; set; }
        [Column("AgroCultureType")]
        public int AgroCultureTypeId { get; set; }
        [RelationColumn(
            ReferenceId = "AgroCultureType",
            FromTable = "_АгроКультуры_Типы",
            PurposeId = "ID",
            FromColumn = "NameOfType"
        )]
        public string AgroCultureType { get; set; }
        [Column("CurrentlySelected")]
        public bool CurrentlySelected { get; set; }
        [Column("AReferendeCultureID")]
        public int ReferendeCultureId { get; set; }
        [RelationColumn(
            ReferenceId = "ReferendeCultureID",
            FromTable = "_АгроКультуры_Справочные",
            PurposeId = "ID",
            FromColumn = "Name"
        )]
        public string ReferenceCulture { get; set; }
        [Column("AvgProductivity")]
        public int AvgProductivity { get; set; }
        [Column("SeedsAvgExpense")]
        public int SeedsAvgExpense { get; set; }
    }
}
