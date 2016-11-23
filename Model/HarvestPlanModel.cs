using Backend.Metadata;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_РасчетПосевов")]
    public class HarvestPlanModel
    {
        [Column("ID")]
        [JsonIgnore]
        public int Id { get; set; }
        [Column("Name")]
        [JsonProperty("Название")]
        public string Name { get; set; }
    }
    [Table("агроном_РасчетПосевов")]
    public class HarvestPlanFullModel : HarvestPlanModel
    {
        [Column("Year")]
        [JsonProperty("Год")]
        public int Year { get; set; }
        [Column("CreatorName")]
        [JsonProperty("Сотрудник")]
        public int CreatorId { get; set; }
        [RelationColumn(
            ReferenceId = "CreatorName",
            FromTable = "_Сотрудники",
            RemoteId = "UserID",
            FromColumn = "FIO"
        )]
        [JsonIgnore]
        public string CreatorName { get; set; }
        [Column("DateOfCreation")]
        [JsonProperty("Дата создания")]
        public int CreationDate { get; set; }
    }
}
