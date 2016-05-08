using Backend.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    [Table("агроном_Севообороты_Названия")]
    public class CropRotationModel
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Type")]
        public int TypeId { get; set; }
        [RelationColumn(
            ReferenceId = "Type",
            FromTable = "_ТипыСевооборотов",
            PurposeId = "ID",
            FromColumn = "NameOfType"
        )]
        public string CropRotationType { get; set; }

    }
    [Table("агроном_Севообороты_Ротация")]
    public class CropRotationFullModel : CropRotationModel
    {
        [Column("YearOfCycle")]
        public int YearOfCycle { get; set; }
        [Column("CropID")]
        public int CropId { get; set; }
        [RelationColumn(
            ReferenceId = "CropID",
            FromTable = "агроном_АгроКультуры",
            PurposeId = "ID",
            FromColumn = "Name"
        )]
        public string AgroCulture { get; set; }
        
    }
}
