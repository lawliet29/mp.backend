using Backend.Metadata;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_ПланУрожая2")]
    public class HarvestPlanElementaryAreaItem
    {
        [Column("PlanID")]
        [JsonIgnore]
        public int Id { get; set; }
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
        [Column("PlannedYield")]
        [JsonProperty("Планируемый урожай")]
        public int PlannedYield { get; set; }
    }
    
}
