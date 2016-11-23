using Backend.Metadata;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_ПоляСевооборотов_История")]
    public class FieldHistoryItem
    {
        [Column("FieldID")]
        [JsonIgnore]
        public int Id { get; set; }
        [Column("Year")]
        [JsonProperty("Год")]
        public int Year { get; set; }
        [Column("CropID")]
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
