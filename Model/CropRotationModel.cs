using Backend.Metadata;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_Севообороты_Названия")]
    public class CropRotationModel
    {
        [Key, Column("ID")]
        [JsonIgnore]
        public int Id { get; set; }
        [Column("Name")]
        [JsonProperty("Название")]
        public string Name { get; set; }
        [Column("Type")]
        [JsonIgnore]
        public int TypeId { get; set; }
        [RelationColumn(
            ReferenceId = "Type",
            FromTable = "_ТипыСевооборотов",
            RemoteId = "ID",
            FromColumn = "NameOfType"
        )]
        [JsonProperty("Тип")]
        public string CropRotationType { get; set; }

    }
    [Table("агроном_Севообороты_Ротация")]
    public class CropRotationFullModel
    {
        [Column("YearOfCycle")]
        [JsonProperty("Год цикла")]
        public int YearOfCycle { get; set; }
        [Key, Column("CropID")]
        [JsonIgnore]
        public int CropId { get; set; }
        [RelationColumn(
            ReferenceId = "CropID",
            FromTable = "агроном_АгроКультуры",
            RemoteId = "ID",
            FromColumn = "Name"
        )]
        [JsonProperty("Агрокультура")]
        public string AgroCulture { get; set; }
        
    }
}
