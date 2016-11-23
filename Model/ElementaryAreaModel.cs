using Backend.Metadata;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_ЭлементраныеУчастки")]
    public class ElementaryAreaModel
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
    [Table("агроном_ЭлементраныеУчастки")]
    public class ElementaryAreaFullModel : ElementaryAreaModel
    {
        [Column("S")]
        [JsonProperty("Площадь")]
        public int PlanarArea { get; set; }
        [Column("Регион")]
        [JsonIgnore]
        public int RegionId { get; set; }
        [RelationColumn(
            ReferenceId = "Регион",
            FromTable = "_Регионы",
            RemoteId = "ID",
            FromColumn = "Name"
        )]
        [JsonProperty("Регион")]
        public string Region { get; set; }
        [Column("Действующий")]
        [JsonProperty("Действующий")]
        public bool Active { get; set; }
        [Column("SoilKind")]
        [JsonIgnore]
        public int SoilKindId { get; set; }
        [RelationColumn(
            ReferenceId = "SoilKind", 
            FromTable = "_ВидПочвы",
            RemoteId = "ID",
            FromColumn = "TypeName"
        )]
        [JsonProperty("Вид почвы")] // TODO: куку
        public string SoilKind { get; set; }
        [Column("SoilClass")]
        [JsonIgnore]
        public int SoilClassId { get; set; }
        [RelationColumn(
            ReferenceId = "SoilClass",
            FromTable = "_КлассПочвы",
            RemoteId = "ID",
            FromColumn = "TypeName"
        )]
        [JsonProperty("Класс почвы")]
        public string SoilClass { get; set; }
        [Column("SoilType")]
        [JsonIgnore]                // TODO: куку
        public int SoilTypeId { get; set; }
        [RelationColumn(
            ReferenceId = "SoilType",
            FromTable = "_ТипыПочвы",
            RemoteId = "ID",
            FromColumn = "TypeName"
        )]
        [JsonProperty("Тип почвы")]
        public string SoilType { get; set; }
    }
}
