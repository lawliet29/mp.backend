using Backend.Metadata;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_ЭлементарныеУчастки_ИсторияПосевов")]
    public class ElementaryAreaHistoryIItem
    {
        [Column("EA_ID")]
        [JsonIgnore]
        public int ElementaryAreaId { get; set; }
        [Column("Year")]
        [JsonProperty("Год")]
        public int Year { get; set; }
        [Column("AgroCultureID")]
        [JsonIgnore]
        public int AgroCultureId { get; set; }
        [RelationColumn(
            ReferenceId = "AgroCultureID",
            FromTable = "агроном_АгроКультуры",
            RemoteId = "ID",
            FromColumn = "Name"
        )]
        [JsonProperty("Агрокультура")]
        public string AgroCulture { get; set; }
        [Column("EaYield")]
        [JsonProperty("Урожай с участка")]
        public int EaYield { get; set; }
        [Column("EaSeedMass")]
        [JsonProperty("Использовано семян")]
        public int EaSeedMass { get; set; }
    }
}
