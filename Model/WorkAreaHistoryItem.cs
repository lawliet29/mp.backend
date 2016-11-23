using Backend.Metadata;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_РабочиеУчестки_ИсторияПосевов")]
    public class WorkAreaHistoryItem
    {
        [Column("WorkAreaID")]
        [JsonIgnore]
        public int Id { get; set; }
        [Column("Year")]
        [JsonProperty("Год")]
        public int Year { get; set; }
        [Column("AgroCultureID")]
        [JsonIgnore]
        public int AgroCultureId { get; set; }
        [RelationColumn(
            ReferenceId = "AgrroCultureID",
            FromTable = "агроном_АгроКультуры",
            RemoteId = "ID",
            FromColumn = "Name"
        )]
        [JsonProperty("Агрокультура")]
        public string AgroCulture { get; set; }
        [Column("WorkAreaYield")]
        [JsonProperty("Урожай с участка")]
        public int WorkAreaYield { get; set; }
        [Column("WorkAreaSeedMass")]
        [JsonProperty("Использовано семян")]
        public int WorkAreaSeedMass { get; set; }
    }
}
