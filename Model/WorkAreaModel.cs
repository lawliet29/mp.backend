using Backend.Metadata;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("агроном_РабочиеУчастки")]
    public class WorkAreaModel
    {
        [Column("ID")]
        [JsonIgnore]
        public int Id { get; set; }
        [Column("Name")]
        [JsonProperty("Название")]
        public string Name { get; set; }
        [Column("Number")]
        [JsonProperty("Номер")]
        public string Number { get; set; }
    }
    [Table("агроном_РабочиеУчастки")]
    public class WorkAreaFullModel : WorkAreaModel
    {
        [Column("Действующий")]
        [JsonProperty("Действующий")]
        public bool Active { get; set; }
    }
}
