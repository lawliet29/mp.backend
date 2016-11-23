using Backend.Metadata;
using System;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_ИсторияПолей_МинУдобрения")]
    public class MineralFertilizerModel
    {
        [Column("ElemAreaID")]
        [JsonIgnore]
        public int ElemAreaId { get; set; }
        [Column("FertilizerCode")]
        [JsonIgnore]
        public int FertilizerId { get; set; }
        [RelationColumn(
            ReferenceId = "FertilizerCode",
            FromTable = "_МинеральныеУдобрения",
            RemoteId = "ID",
            FromColumn = "Name"
        )]
        [JsonProperty("Удобрение")]
        public string Fertilizer { get; set; }
    }
    [Table("агроном_ИсторияПолей_МинУдобрения")]
    public class MineralFertilizerFullModel : MineralFertilizerModel
    {
        [Column("FertilizationDate")]
        [JsonProperty("Дата внесения")]
        public DateTime FertilizationDate { get; set; }
        [Column("FertilizerWeight")]
        [JsonProperty("Вес")]
        public int FertilizerWeight { get; set; }
        [Column("S")]
        [JsonProperty("S")]
        public int S { get; set; }
        [Column("N")]
        [JsonProperty("N")]
        public int N { get; set; }
        [Column("P2O5")]
        [JsonProperty("P2O5")]
        public int P2O5 { get; set; }
        [Column("K2O")]
        [JsonProperty("K2O")]
        public int K2O { get; set; }
        [Column("Price")]
        [JsonProperty("Цена")]
        public int Price { get; set; }
        
    }
}
