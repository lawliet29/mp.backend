using Backend.Metadata;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_РасчетПосевов2")]
    public class PaymentCropElementaryAreaItem
    {
        [Column("OptimizationID")]
        [JsonIgnore]
        public int Id { get; set; }
        [Column("EA_ID")]
        [JsonIgnore]
        public int ElementaryAreaId { get; set; }
    }
    [Table("агроном_РасчетПосевов2")]
    public class PaymentCropElementaryAreaFullModel : AgroCultureModel
    {
        [Column("AgroCultureID")]
        [JsonIgnore]
        public int AgroCultureId { get; set; }
        [RelationColumn(
            ReferenceId = "AgroCultureID",
            FromTable = "агроном_АгроКультуры",
            RemoteId = "ID",
            FromColumn = "ProductionType"
        )]
        [JsonProperty("Агрокультура")]
        public string AgroCulture { get; set; }
        [Column("PlannedProductivity")]
        [JsonProperty("Планируемая урожайность")]
        public int PlannedProductivity { get; set; }
        [Column("Ka_ToAdd")]
        public int KaToAdd { get; set; }
        [Column("P_ToAdd")]
        public int PToAdd { get; set; }
        [Column("N_ToAdd")]
        public int NToAdd { get; set; }
    }
}
