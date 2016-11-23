using Backend.Metadata;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_ПоляСевооборотов")]
    public class FieldModel
    {
        [Column("ID")]
        [JsonIgnore]
        public int Id { get; set; }
        [Column("Name")]
        [JsonProperty("Название")]
        public string Name { get; set; }
        [Column("Number")]
        [JsonProperty("Номер")]
        public int Number { get; set; }
    }
    [Table("агроном_ПоляСевооборотов")]
    public class FieldFullModel : WorkAreaModel
    {
        [Column("Действует")]
        [JsonProperty("Действующее")]
        public bool Active { get; set; }
        [Column("CropRotationId")]
        [JsonIgnore]
        public int CropRotationId { get; set; }
        [RelationColumn(
            ReferenceId = "CropRotationId",
            FromTable = "_Севообороты_Названия",
            RemoteId = "ID",
            FromColumn = "Name"
        )]
        [JsonProperty("Севооборот")]
        public string CropRotation { get; set; }
        [Column("InitialYearOfCycle")]
        [JsonProperty("Начальный номер года в цикле севооборота")]
        public int InitialYear { get; set; }
        [Column("StartYear")]
        [JsonProperty("Год ввода севооборота на данном поле")]
        public int StartYear { get; set; }
        [Column("ElemAreaID")]
        public ICollection<ElementaryAreaModel> FieldComposition { get; set; }         // TODO 
    }
}
