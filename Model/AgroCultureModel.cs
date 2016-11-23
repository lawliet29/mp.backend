using Backend.Metadata;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_АгроКультуры")]
    public class AgroCultureModel
    {
        [Key, Column("ID")]
        [JsonIgnore]
        public int Id { get; set; }
        [Column("Name")]
        [JsonProperty("Название")]
        public string Name { get; set; }
    }
    [Table("агроном_АгроКультуры")]
    public class AgroCultureFullModel : AgroCultureModel
    {
        [Column("AddedByUser")]
        [JsonProperty("Добавлено пользователем")]
        public bool AddedByUser { get; set; }
        [Column("ProductionType")]
        [JsonIgnore]
        public int ProductionTypeId { get; set; }
        [RelationColumn(
            ReferenceId = "ProductionType",
            FromTable = "_АгроКультуры_ПроизводственныеТипы",
            RemoteId = "ID",
            FromColumn = "NameOfType"
        )]
        [JsonProperty("Производственный тип")]
        public string ProductionType { get; set; }
        [Column("BiologicalType")]
        [JsonIgnore]
        public int BiologicalTypeId { get; set; }
        [RelationColumn(
            ReferenceId = "BiologicalType",
            FromTable = "_АгроКультуры_БиологическиеТипы",
            RemoteId = "ID",
            FromColumn = "NameOfType"
        )]
        [JsonProperty("Биологический тип")]
        public string BiologicalType { get; set; }
        [Column("Intermediate")]
        [JsonProperty("Промежуточная культура")]
        public bool Intermediate { get; set; }
        [Column("AgroCultureType")]
        [JsonIgnore]
        public int AgroCultureTypeId { get; set; }
        [RelationColumn(
            ReferenceId = "AgroCultureType",
            FromTable = "_АгроКультуры_Типы",
            RemoteId = "ID",
            FromColumn = "NameOfType"
        )]
        [JsonProperty("Тип")]
        public string AgroCultureType { get; set; }
        [Column("CurrentlySelected")]
        [JsonProperty("Выделены в данный момент")]
        public bool CurrentlySelected { get; set; }
        [Column("AReferendeCultureID")]
        [JsonIgnore]
        public int ReferenсeCultureId { get; set; }
        [RelationColumn(
            ReferenceId = "ReferendeCultureID",
            FromTable = "_АгроКультуры_Справочные",
            RemoteId = "ID",
            FromColumn = "Name"
        )]
        [JsonProperty("Схожая справочная культура")]
        public string ReferenceCulture { get; set; }
        [Column("AvgProductivity")]
        [JsonProperty("Средняя урожайность")]
        public int AvgProductivity { get; set; }
        [Column("SeedsAvgExpense")]
        [JsonProperty("Средний расход семян")]
        public int SeedsAvgExpense { get; set; }
    }
}
