using Backend.Metadata;
using Newtonsoft.Json;

namespace Backend.Model
{
    [Table("_Сотрудники")]
    public class EmployeeModel
    {
        [Column("ID")]
        [JsonIgnore]
        public int Id { get; set; }
        [Column("FIO")]
        [JsonProperty("ФИО")]
        public string Name { get; set; }
        [Column("Password")]
        [JsonIgnore]
        public string Password { get; set; }
    }
    
}
