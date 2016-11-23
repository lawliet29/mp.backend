using Backend.Metadata;
using System;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_РасчетПосевов")]
    public class PaymentCropModel
    {
        [Column("ID")]
        [JsonIgnore]
        public int Id { get; set; }
        [Column("Name")]
        [JsonProperty("Название")]
        public string Name { get; set; }
    }
    [Table("агроном_РасчетПосевов")]
    public class PaymentCropFullModel : AgroCultureModel
    {
        [Column("Staffer")]
        [JsonIgnore]
        public int EmployeeId { get; set; }
        [RelationColumn(
            ReferenceId = "Staffer",
            FromTable = "_Сотрудники",
            RemoteId = "UserID",
            FromColumn = "FIO"
        )]
        [JsonProperty("Сотрудник")]
        public string Employee { get; set; }
        [Column("Year")]
        [JsonProperty("Год")]
        public int Year{ get; set; }
        [Column("StoreRequestID")]
        [JsonIgnore]
        public int StoreRequestId { get; set; }
        [RelationColumn(
            ReferenceId = "StoreRequestID",
            FromTable = "агроном_ПланУрожая_1",
            RemoteId = "PlanID",
            FromColumn = "Name"
        )]
        [JsonProperty("План урожая")]
        public string StoreRequest { get; set; }
        [Column("DateOfCreation")]
        [JsonProperty("Дата составления")]
        public DateTime CreationDate { get; set; }
        [Column("Примечание")]
        [JsonProperty("Примечание")]
        public string Note { get; set; }
    }
}
